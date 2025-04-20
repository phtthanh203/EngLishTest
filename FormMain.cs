using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishTest
{
    public partial class FormMain : Form
    {
        string connectionString = @"Data Source=LAPTOP-VR8TF3S0;Initial Catalog=DB_CauHoi;Integrated Security=True";

        public FormMain()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10F);
            this.BackColor = Color.WhiteSmoke;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadLanguages();
            LoadLevels();
        }

        private void LoadLanguages()
        {
            comboBox1.Items.Clear();
            string query = "SELECT DISTINCT Language FROM Questions";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Language"].ToString());
                }
            }
        }

        private void LoadLevels()
        {
            comboBox2.Items.Clear();
            string query = "SELECT DISTINCT Level FROM Questions";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["Level"].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyCauHoi quanly = new QuanLyCauHoi();
            quanly.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedLanguage = comboBox1.SelectedItem?.ToString();
            string selectedLevel = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedLanguage) || string.IsNullOrEmpty(selectedLevel))
            {
                MessageBox.Show("Please select both Language and Level.");
                return;
            }

            Form1 displayForm = new Form1(selectedLanguage, selectedLevel);
            displayForm.Show();
            this.Hide();
        }
    }
}
