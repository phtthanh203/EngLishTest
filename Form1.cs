using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishTest
{
    public partial class Form1 : Form
    {
        List<Question> questions = new List<Question>();
        Dictionary<int, int> userAnswers = new Dictionary<int, int>();
        int currentQuestionIndex = 0;

        string selectedLanguage;
        string selectedLevel;

        public Form1()
        {
            
        }
        public Form1(string language, string level)
        {
            InitializeComponent();
            selectedLanguage = language;
            selectedLevel = level;
            this.Load += Form1_Load;

            // Title label
            label1.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(30, 30, 60);
            label1.TextAlign = ContentAlignment.MiddleLeft;

            // ListView
            listView1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            listView1.BackColor = Color.WhiteSmoke;
            listView1.ForeColor = Color.FromArgb(40, 40, 40);
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.FullRowSelect = true;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            // GroupBox
            groupBox1.Text = "Question Panel";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(30, 30, 30);
            groupBox1.BackColor = Color.WhiteSmoke;

            // Question label
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(20, 20, 80);

            // Radio buttons
            RadioButton[] radios = { radioButton1, radioButton2, radioButton3, radioButton4 };
            foreach (var rb in radios)
            {
                rb.Font = new Font("Segoe UI", 11F);
                rb.ForeColor = Color.FromArgb(30, 30, 30);
                rb.AutoSize = true;
                rb.CheckedChanged += HandleAnswerSelection;
            }

            // Buttons
            Button[] buttons = { button1, button2, button3 };
            Color[] colors = { Color.SteelBlue, Color.Gray, Color.SeaGreen };
            string[] texts = { "NEXT", "BACK", "SUBMIT" };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = texts[i];
                buttons[i].Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].BackColor = colors[i];
                buttons[i].ForeColor = Color.White;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].Size = new Size(100, 36);
            }

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;

            // ProgressBar
            progressBar1.ForeColor = Color.MediumSeaGreen;
            progressBar1.Style = ProgressBarStyle.Continuous;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            questions = LoadQuestionsFromDatabase();
            listView1.Items.Clear();

            for (int i = 0; i < questions.Count; i++)
                listView1.Items.Add($"Question {i + 1}");

            progressBar1.Minimum = 0;
            progressBar1.Maximum = questions.Count;
            progressBar1.Value = 0;

            DisplayQuestion(currentQuestionIndex);
            UpdateNavButtons();
        }

        private void DisplayQuestion(int index)
        {
            if (index < 0 || index >= questions.Count) return;

            listView1.SelectedIndexChanged -= listView1_SelectedIndexChanged;

            label3.Text = questions[index].Content;
            radioButton1.Text = questions[index].Answers[0];
            radioButton2.Text = questions[index].Answers[1];
            radioButton3.Text = questions[index].Answers[2];
            radioButton4.Text = questions[index].Answers[3];

            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;

            if (userAnswers.ContainsKey(index))
            {
                switch (userAnswers[index])
                {
                    case 0: radioButton1.Checked = true; break;
                    case 1: radioButton2.Checked = true; break;
                    case 2: radioButton3.Checked = true; break;
                    case 3: radioButton4.Checked = true; break;
                }
            }

            listView1.SelectedItems.Clear();
            listView1.Items[index].Selected = true;
            listView1.EnsureVisible(index);

            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            UpdateListViewHighlighting();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                currentQuestionIndex = listView1.SelectedItems[0].Index;
                DisplayQuestion(currentQuestionIndex);
                UpdateNavButtons();
            }
        }

        private void HandleAnswerSelection(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            int index = listView1.SelectedItems[0].Index;
            int selectedAnswer = -1;
            if (radioButton1.Checked) selectedAnswer = 0;
            else if (radioButton2.Checked) selectedAnswer = 1;
            else if (radioButton3.Checked) selectedAnswer = 2;
            else if (radioButton4.Checked) selectedAnswer = 3;

            if (selectedAnswer != -1)
            {
                bool isNewSelection = !userAnswers.ContainsKey(index);
                userAnswers[index] = selectedAnswer;

                if (isNewSelection)
                    progressBar1.Value = Math.Min(progressBar1.Value + 1, questions.Count);

                UpdateListViewHighlighting();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayQuestion(currentQuestionIndex);
                UpdateNavButtons();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                DisplayQuestion(currentQuestionIndex);
                UpdateNavButtons();
            }
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            int correctCount = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (userAnswers.ContainsKey(i) && userAnswers[i] == questions[i].CorrectAnswerIndex)
                    correctCount++;
            }

            MessageBox.Show($"Bạn trả lời đúng {correctCount}/{questions.Count} câu.\nĐiểm: {(correctCount * 10.0 / questions.Count):0.0}/10", "Kết quả");

            this.Close(); 
        }


        private void UpdateNavButtons()
        {
            button1.Enabled = currentQuestionIndex < questions.Count - 1;
            button2.Enabled = currentQuestionIndex > 0;
        }

        private void UpdateListViewHighlighting()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var item = listView1.Items[i];

                if (i == currentQuestionIndex)
                {
                    item.BackColor = Color.DodgerBlue;
                    item.ForeColor = Color.White;
                }
                else if (userAnswers.ContainsKey(i))
                {
                    item.BackColor = Color.LightGreen;
                    item.ForeColor = Color.Black;
                }
                else
                {
                    item.BackColor = Color.White;
                    item.ForeColor = Color.Black;
                }
            }

            listView1.Items[currentQuestionIndex].Selected = true;
            listView1.Select();
        }

        private List<Question> LoadQuestionsFromDatabase()
        {
            var questions = new List<Question>();
            string connectionString = @"Data Source=LAPTOP-VR8TF3S0;Initial Catalog=DB_CauHoi;Integrated Security=True";
            string query = "SELECT Content, Answer1, Answer2, Answer3, Answer4, CorrectAnswerIndex FROM Questions WHERE Language = @Language AND Level = @Level";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Language", selectedLanguage);
                    cmd.Parameters.AddWithValue("@Level", selectedLevel);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var question = new Question
                        {
                            Content = reader.GetString(0),
                            Answers = new[]
                            {
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    },
                            CorrectAnswerIndex = reader.GetInt32(5)
                        };
                        questions.Add(question);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return questions;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
