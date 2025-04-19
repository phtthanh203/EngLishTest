using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyCauHoi quanly = new QuanLyCauHoi();
            quanly.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e); 
            comboBox2_SelectedIndexChanged(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        string connectionString = @"Data Source=PHTTHANH203;Initial Catalog=DB_CauHoi;Integrated Security=True";

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedLanguage = comboBox1.SelectedItem?.ToString();
            string selectedLevel = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedLanguage) || string.IsNullOrEmpty(selectedLevel))
            {
                MessageBox.Show("Please select both Language and Level.");
                return;
            }

            // Gửi Language và Level sang FormDisplayQuestion
            Form1 displayForm = new Form1(selectedLanguage, selectedLevel);
            displayForm.Show();
            this.Hide(); // Ẩn form chọn mode nếu muốn
        }
    }
}
