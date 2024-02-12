using LABA1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StudentRepository studentRepository = new StudentRepository();
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
                Student student = new Student(firstName, lastName, day, month, year);
                studentRepository.save(student, "D:\\C#Labs\\LABA1\\LABA1\\StudentsList.txt");
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
            form2.Show();
            this.Hide(); 
        }
    }
}
