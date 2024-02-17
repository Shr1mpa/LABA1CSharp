using LABA1.Classes;
using System;
using System.Windows.Forms;

namespace LABA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileManager _fileManager = new FileManager();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            int day, month, year;
            try
            {
                day = int.Parse(textBox3.Text);
                month = int.Parse(textBox4.Text);
                year = int.Parse(textBox5.Text);
                StudentVm student = new StudentVm(firstName, lastName, day, month, year);
                _fileManager.Save(student);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                MessageBox.Show("Student added");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListForm form2 = new ListForm();
            form2.ShowDialog();
             
        }
    }
}
