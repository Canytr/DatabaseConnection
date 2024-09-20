using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseConnection
{
    public partial class Form1 : Form
    {

        private Logger _logger;

        public Form1()
        {
            InitializeComponent();

            // We create the Logger object and pass the RichTextBox reference
            _logger = new Logger(richTextBoxLog);

            txtConnectionString.AppendText("Data Source=DESKTOP-9FBPMP7\\SQLEXPRESS;Initial Catalog=Help_Menu;Integrated Security=True;Pooling=False;Encrypt=False\r\n");
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;

            // Load the commands from the file when the form opens
            LoadCommandsFromFile();
        }

        private void FetchTableNames(SqlConnection connection)
        {
            // SQL query to retrieve table names
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Add the table names to the ComboBox
                    cmbTables.Items.Add(reader["TABLE_NAME"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve table names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchAndDisplayData(SqlConnection connection)
        {
            // Get the table name selected from the ComboBox
            string selectedTable = cmbTables.SelectedItem.ToString();
            string query = $"SELECT TOP 10 * FROM {selectedTable}"; // Load top 10 row

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            try
            {
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable; // Load data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data retrieval failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This event is triggered when a table is selected in the ComboBox.
            string connectionString = txtConnectionString.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    FetchAndDisplayData(connection); // Show data
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Data retrieval failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            string connectionString = txtConnectionString.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _logger.LogMessage("Connection successful!", Logger.LogLevel.Info);

                    // Retrieve the table names and load them into the ComboBox
                    FetchTableNames(connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _logger.LogMessage($"Connection failed: {ex.Message}", Logger.LogLevel.Error);
                }
            }
        }

        // Method to execute the SQL command
        private void ExecuteSqlCommand(SqlConnection connection)
        {
            string query = richTextBoxSql.Text; 

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a valid SQL command.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlCommand command = new SqlCommand(query, connection);

            try
            {

                _logger.LogMessage($"Executing SQL Command: {query}", Logger.LogLevel.Info);

                if (query.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                {
                    // If it is a SELECT query, retrieve the data and display it in the DataGridView
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                else
                {
                    // For commands other than SELECT (INSERT, UPDATE, DELETE, etc.), we use ExecuteNonQuery
                    int affectedRows = command.ExecuteNonQuery();
                    MessageBox.Show($"{affectedRows} rows affected.", "Execution Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _logger.LogMessage($"{affectedRows} rows affected by the command.", Logger.LogLevel.Info);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SQL execution failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.LogMessage($"SQL execution failed: {ex.Message}", Logger.LogLevel.Error);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string connectionString = txtConnectionString.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    ExecuteSqlCommand(connection); // Run Sql command
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string connectionString = txtConnectionString.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Clear the table names in the ComboBox
                    cmbTables.Items.Clear();

                    // Retrieve the table names from the database again and add them to the ComboBox
                    FetchTableNames(connection);

                    MessageBox.Show("Data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Data refresh failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string addTableScript = @"
            CREATE TABLE DatabaseDocument
            (
                DocumentID INT IDENTITY(1,1) PRIMARY KEY,   -- Benzersiz belge kimliği (otomatik artan)
                Title NVARCHAR(255) NOT NULL,               -- Belge başlığı
                Content NVARCHAR(MAX) NOT NULL              -- Belge içeriği
            );";

            richTextBoxSql.Text = addTableScript; 
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            string deleteTableScript = "DROP TABLE DatabaseDocument;";

            richTextBoxSql.Text = deleteTableScript; 
        }

        // SQL Command (title + command)
        private List<SqlCommandEntry> sqlCommands = new List<SqlCommandEntry>();

        // Set the file path for SavedCommands.txt to the project root directory
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../SavedCommands.txt");

        private void btnSaveCommand_Click(object sender, EventArgs e)
        {
            string command = richTextBoxSql.Text;

            if (!string.IsNullOrWhiteSpace(command))
            {
                // Prompt the user to enter a title
                string title = Prompt.ShowDialog("Please enter a title for the SQL command:", "Save SQL Command");

                if (!string.IsNullOrWhiteSpace(title))
                {
                    // Create a new SQL command entry
                    SqlCommandEntry newEntry = new SqlCommandEntry
                    {
                        Title = title,
                        Command = command
                    };

                    sqlCommands.Add(newEntry);
                    File.AppendAllText(filePath, title + Environment.NewLine + command + Environment.NewLine);

                    // Update the list in the UI
                    listBoxCommands.Items.Add(newEntry);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid SQL command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCommandsFromFile()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i += 2)
                {
                    if (i + 1 < lines.Length)
                    {
                        // Create title and command pairs
                        string title = lines[i];
                        string command = lines[i + 1];

                        SqlCommandEntry entry = new SqlCommandEntry
                        {
                            Title = title,
                            Command = command
                        };

                        // Add to the list
                        sqlCommands.Add(entry);
                        listBoxCommands.Items.Add(entry);
                    }
                }
            }
        }

        private void btnLoadCommand_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                SqlCommandEntry selectedEntry = (SqlCommandEntry)listBoxCommands.SelectedItem;
                richTextBoxSql.Text = selectedEntry.Command;
            }
        }

        private void btnEditCommand_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                SqlCommandEntry selectedEntry = (SqlCommandEntry)listBoxCommands.SelectedItem;

                string newCommand = richTextBoxSql.Text;

                // Update List
                selectedEntry.Command = newCommand;
                UpdateCommandsFile();

                MessageBox.Show("Command updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to update the commands file
        private void UpdateCommandsFile()
        {
            List<string> lines = new List<string>();

            foreach (var entry in sqlCommands)
            {
                lines.Add(entry.Title);
                lines.Add(entry.Command);
            }

            File.WriteAllLines(filePath, lines);
        }

        private void btnDeleteCommand_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                string selectedTitle = listBoxCommands.SelectedItem.ToString();

                // Find the command by title
                var commandToRemove = sqlCommands.FirstOrDefault(cmd => cmd.Title == selectedTitle);

                if (commandToRemove != null)
                {
                    // Remove the command from the list
                    sqlCommands.Remove(commandToRemove);
                    listBoxCommands.Items.Remove(selectedTitle);
                    listBoxCommands.ClearSelected();
                    listBoxCommands.Refresh();

                    // Update the records in the file with titles and commands
                    List<string> updatedCommands = new List<string>();
                    foreach (var command in sqlCommands)
                    {
                        // Save each command as a title and script
                        updatedCommands.Add(command.Title + Environment.NewLine + command.Command);
                    }

                    // Update File
                    File.WriteAllLines(filePath, updatedCommands);
                }
                else
                {
                    MessageBox.Show("Command not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string connectionString = txtConnectionString.Text;
            string selectedTable = cmbTables.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create a SELECT query
                    string query = $"SELECT * FROM {selectedTable}";

                    // Retrieve data using DataAdapter
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Settings for UpdateCommand, InsertCommand, and DeleteCommand
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Update DataTable
                    DataTable changes = ((DataTable)dataGridView.DataSource).GetChanges();

                    if (changes != null)
                    {
                        // Send changes to the database
                        int updatedRows = dataAdapter.Update(changes);

                        // Notify if there are changes
                        MessageBox.Show($"{updatedRows} rows updated in the database.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Accept changes
                        ((DataTable)dataGridView.DataSource).AcceptChanges();
                    }
                    else
                    {
                        MessageBox.Show("No changes detected.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // OpenFileDialog oluşturuyoruz
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*"; // İstediğiniz dosya türüne göre filtre ekleyebilirsiniz
            openFileDialog.Title = "Bir dosya seçin";

            // Eğer kullanıcı bir dosya seçip "OK" butonuna basarsa
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Seçilen dosyanın içeriğini okuyup RichTextBox'a aktarıyoruz
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    richTextBoxDocument.Text = fileContent;
                }
                catch (Exception ex)
                {
                    // Hata yakalayıp mesaj gösteriyoruz
                    MessageBox.Show("Dosya okunurken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            //not implemented
        }

        private void btnPhrase_Click(object sender, EventArgs e)
        {
            //not implemented
        }
    }
}
