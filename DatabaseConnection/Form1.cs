using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DatabaseConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtConnectionString.AppendText("Data Source=DESKTOP-9FBPMP7\\SQLEXPRESS;Initial Catalog=Help_Menu;Integrated Security=True;Pooling=False;Encrypt=False\r\n");
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged; // ComboBox'taki seçim değişikliğini dinliyoruz
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // İsteğe bağlı: TextBox içeriği değiştikçe yapılacak işlemler burada olabilir.
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
                    LogMessage("Connection successful!");

                    // Tablo isimlerini al ve ComboBox'a yükle
                    FetchTableNames(connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogMessage($"Connection failed: {ex.Message}");
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

                LogMessage($"Executing SQL Command: {query}");

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
                    LogMessage($"{affectedRows} rows affected by the command.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SQL execution failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage($"SQL execution failed: {ex.Message}");
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


        //Log Messages
        private void LogMessage(string message)
        {
            // Log mesajını zaman damgasıyla RichTextBox'a ekle
            richTextBoxLog.AppendText($"{DateTime.Now}: {message}\r\n");

            // En son log mesajını görünür yapmak için imleci en sona kaydır
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }


    }
}
