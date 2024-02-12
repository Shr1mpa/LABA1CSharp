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
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }
        StudentRepository studentRepository = new StudentRepository();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            studentRepository.load("D:\\C#Labs\\LABA1\\LABA1\\StudentsList.txt");


            foreach (var student in studentRepository.getStudents())
            {
                string birthDate = $"{student.Day:D2}/{student.Month:D2}/{student.Year}";
                dataGridView1.Rows.Add(student.FirstName, student.LastName, birthDate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if (Enum.IsDefined(typeof(Month), text))
            {
                Month selectedMonth = (Month)Enum.Parse(typeof(Month), text);
                int monthValue = (int)selectedMonth;
                List<Student> students = studentRepository.sortStudentByMonth(monthValue);
                dataGridView1.Rows.Clear();
                foreach (var student in students)
                {
                    string birthDate = $"{student.Day:D2}/{student.Month:D2}/{student.Year}";
                    dataGridView1.Rows.Add(student.FirstName, student.LastName, birthDate);
                }

            }
            else
            {
                MessageBox.Show("Month not found" );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentRepository.load("D:\\C#Labs\\LABA1\\LABA1\\StudentsList.txt");
            dataGridView1.Rows.Clear();

            foreach (var student in studentRepository.getStudents())
            {
                string birthDate = $"{student.Day:D2}/{student.Month:D2}/{student.Year}";
                dataGridView1.Rows.Add(student.FirstName, student.LastName, birthDate);
            }
        }
    }
}
