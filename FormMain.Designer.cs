using System.Drawing;
using System.Windows.Forms;
using System;

namespace EnglishTest
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private Button button1;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private ComboBox comboBox2;
        private Button button2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.comboBox1 = new ComboBox();
            this.label4 = new Label();
            this.comboBox2 = new ComboBox();
            this.button2 = new Button();
            this.button1 = new Button();
            this.SuspendLayout();

            this.ClientSize = new Size(650, 400);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "🎓 English Test App";
            this.Load += new EventHandler(this.FormMain_Load);


            this.label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.label1.ForeColor = Color.FromArgb(30, 144, 255);
            this.label1.Location = new Point(0, 20);
            this.label1.Size = new Size(650, 70);
            this.label1.Text = "✨ Welcome to Quizz Test ✨";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;

            this.label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.label2.Location = new Point(180, 90);
            this.label2.Size = new Size(290, 35);
            this.label2.Text = "🎯 Select Your Mode";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;

            this.label3.Font = new Font("Segoe UI", 12F);
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(60, 145);
            this.label3.Size = new Size(110, 25);
            this.label3.Text = "🌐 Language:";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;

            this.comboBox1.Font = new Font("Segoe UI", 12F);
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new Point(175, 142);
            this.comboBox1.Size = new Size(170, 35);
            this.comboBox1.BackColor = Color.WhiteSmoke;
            this.comboBox1.ForeColor = Color.Black;
            this.comboBox1.FlatStyle = FlatStyle.Standard;

            this.label4.Font = new Font("Segoe UI", 12F);
            this.label4.Location = new Point(380, 145);
            this.label4.Size = new Size(80, 25);
            this.label4.Text = "📊 Level:";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;


            this.comboBox2.Font = new Font("Segoe UI", 12F);
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.Location = new Point(460, 142);
            this.comboBox2.Size = new Size(120, 35);
            this.comboBox2.BackColor = Color.WhiteSmoke;
            this.comboBox2.ForeColor = Color.Black;
            this.comboBox2.FlatStyle = FlatStyle.Standard;

            this.button2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.button2.BackColor = Color.FromArgb(0, 123, 255);
            this.button2.ForeColor = Color.White;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new Point(205, 230);
            this.button2.Size = new Size(240, 60);
            this.button2.Text = "🚀 START QUIZ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button2.MouseEnter += (s, e) => button2.BackColor = Color.FromArgb(0, 102, 204);
            this.button2.MouseLeave += (s, e) => button2.BackColor = Color.FromArgb(0, 123, 255);

            this.button1.Font = new Font("Segoe UI", 10F);
            this.button1.BackColor = Color.FromArgb(80, 80, 80);
            this.button1.ForeColor = Color.White;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new Point(20, 340);
            this.button1.Size = new Size(160, 40);
            this.button1.Text = "🛠 Manage Questions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button1.MouseEnter += (s, e) => button1.BackColor = Color.FromArgb(60, 60, 60);
            this.button1.MouseLeave += (s, e) => button1.BackColor = Color.FromArgb(80, 80, 80);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);

            this.ResumeLayout(false);
        }
    }
}
