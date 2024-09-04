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

                    // Tablo isimlerini al ve ComboBox'a yükle
                    FetchTableNames(connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
