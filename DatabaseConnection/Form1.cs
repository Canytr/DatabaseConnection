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

            // Logger nesnesini oluşturuyoruz ve RichTextBox referansını veriyoruz
            _logger = new Logger(richTextBoxLog);

            txtConnectionString.AppendText("Data Source=DESKTOP-9FBPMP7\\SQLEXPRESS;Initial Catalog=Help_Menu;Integrated Security=True;Pooling=False;Encrypt=False\r\n");
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged; // ComboBox'taki seçim değişikliğini dinliyoruz

            // Dosyadaki komutları form açılışında yükleyelim
            LoadCommandsFromFile();
        }

        private void FetchTableNames(SqlConnection connection)
        {
            // Tablo isimlerini almak için SQL sorgusu
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Tablo isimlerini ComboBox'a ekle
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
            // ComboBox'tan seçilen tablo ismini al
            string selectedTable = cmbTables.SelectedItem.ToString();
            string query = $"SELECT TOP 10 * FROM {selectedTable}"; // İstediğiniz sorgu logic'i

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            try
            {
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable; // Verileri DataGridView'e yükle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data retrieval failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'ta bir tablo seçildiğinde bu olay tetiklenir.
            string connectionString = txtConnectionString.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    FetchAndDisplayData(connection); // Verileri göster
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Data retrieval failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            // Bağlantı dizesini al
            string connectionString = txtConnectionString.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _logger.LogMessage("Connection successful!", Logger.LogLevel.Info);

                    // Tablo isimlerini al ve ComboBox'a yükle
                    FetchTableNames(connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _logger.LogMessage($"Connection failed: {ex.Message}", Logger.LogLevel.Error);
                }
            }
        }

        //SQL
        // SQL Komutunu çalıştıran metot
        private void ExecuteSqlCommand(SqlConnection connection)
        {
            string query = richTextBoxSql.Text; // TextBox'taki SQL komutunu alıyoruz

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
                    // Eğer bir SELECT sorgusuysa verileri getirip DataGridView'e gösteriyoruz
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                else
                {
                    // SELECT dışındaki komutlar için (INSERT, UPDATE, DELETE, vb.) ExecuteNonQuery kullanıyoruz
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
                    ExecuteSqlCommand(connection); // SQL komutunu çalıştır
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

                    // ComboBox'taki tablo isimlerini temizle
                    cmbTables.Items.Clear();

                    // Veritabanından tablo isimlerini yeniden al ve ComboBox'a ekle
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
            // SQL scriptini RichTextBox'a ekleyelim
            string addTableScript = @"
            CREATE TABLE DatabaseDocument
            (
                DocumentID INT IDENTITY(1,1) PRIMARY KEY,   -- Benzersiz belge kimliği (otomatik artan)
                Title NVARCHAR(255) NOT NULL,               -- Belge başlığı
                Content NVARCHAR(MAX) NOT NULL              -- Belge içeriği
            );";

            richTextBoxSql.Text = addTableScript; // Scripti RichTextBox'a ekle
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            // SQL scriptini RichTextBox'a ekleyelim
            string deleteTableScript = "DROP TABLE DatabaseDocument;";

            richTextBoxSql.Text = deleteTableScript; // Scripti RichTextBox'a ekle
        }


        //
        // SQL komutları için liste (başlık + komut)
        private List<SqlCommandEntry> sqlCommands = new List<SqlCommandEntry>();

        // SavedCommands.txt dosya yolunu proje kök dizinine yönlendiriyoruz
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../SavedCommands.txt");

        private void btnSaveCommand_Click(object sender, EventArgs e)
        {
            string command = richTextBoxSql.Text;

            if (!string.IsNullOrWhiteSpace(command))
            {
                // Kullanıcıdan başlık girmesini iste
                string title = Prompt.ShowDialog("Please enter a title for the SQL command:", "Save SQL Command");

                if (!string.IsNullOrWhiteSpace(title))
                {
                    // Yeni SQL komut girişini oluştur
                    SqlCommandEntry newEntry = new SqlCommandEntry
                    {
                        Title = title,
                        Command = command
                    };

                    // Listeye ekle
                    sqlCommands.Add(newEntry);

                    // Dosyaya kaydet
                    File.AppendAllText(filePath, title + Environment.NewLine + command + Environment.NewLine);

                    // Listeyi UI'de güncelle
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
                        // Başlık ve komut çiftlerini oluştur
                        string title = lines[i];
                        string command = lines[i + 1];

                        SqlCommandEntry entry = new SqlCommandEntry
                        {
                            Title = title,
                            Command = command
                        };

                        // Listeye ekle
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

                // Listeyi güncelle
                selectedEntry.Command = newCommand;
                UpdateCommandsFile();

                MessageBox.Show("Command updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // SQL komutlarının dosyasını güncellemek için metod
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
                string selectedTitle = listBoxCommands.SelectedItem.ToString(); // Seçilen başlık

                // Başlık üzerinden komutu buluyoruz
                var commandToRemove = sqlCommands.FirstOrDefault(cmd => cmd.Title == selectedTitle);

                if (commandToRemove != null)
                {
                    // Listeden komutu siliyoruz
                    sqlCommands.Remove(commandToRemove);
                    listBoxCommands.Items.Remove(selectedTitle); // ListBox'tan başlığı siliyoruz

                    // Seçimi sıfırlıyoruz
                    listBoxCommands.ClearSelected();

                    // ListBox'ı yenile
                    listBoxCommands.Refresh();

                    // Dosyadaki kayıtları başlık ve komutlar ile güncelliyoruz
                    List<string> updatedCommands = new List<string>();
                    foreach (var command in sqlCommands)
                    {
                        // Her komutu başlık ve script şeklinde kaydediyoruz
                        updatedCommands.Add(command.Title + Environment.NewLine + command.Command);
                    }

                    // Dosyayı güncelle
                    File.WriteAllLines(filePath, updatedCommands);
                }
                else
                {
                    MessageBox.Show("Command not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
