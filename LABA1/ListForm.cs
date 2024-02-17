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
        private FileManager _fileManager;
        private List<StudentVm> _students;
       
        public ListForm()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            _students = new List<StudentVm>();
            
            
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListForm_Load(object sender, EventArgs e)
        {
             _fileManager.Load();
            _students = _fileManager.Students;
            foreach (var student in _fileManager.Students)
            {
                string birthDate = $"{student.Birthday.Day:D2}/{(int)student.Birthday.Month:D2}/{student.Birthday.Year}";
                dataGridView1.Rows.Add(student.FirstName, student.LastName, birthDate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if (Enum.IsDefined(typeof(MonthVm), text))
            {
                MonthVm selectedMonth = (MonthVm)Enum.Parse(typeof(MonthVm), text);
                int monthValue = (int)selectedMonth;
                List<StudentVm> sortedStudents = _students
                                     .Where(student => (int)student.Birthday.Month == monthValue)
                                     .OrderBy(student => student.Birthday.Year)
                                     .ThenBy(student => student.Birthday.Day)
                                     .ToList();

                dataGridView1.Rows.Clear();
                foreach (var student in sortedStudents)
                {
                    string birthDate = $"{student.Birthday.Day:D2}/{(int)student.Birthday.Month:D2}/{student.Birthday.Year}";
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
            _students.Clear();
            _fileManager.Load();
            dataGridView1.Rows.Clear();

            foreach (var student in _students)
            {
                string birthDate = $"{student.Birthday.Day:D2}/{(int)student.Birthday.Month:D2}/{student.Birthday.Year}";
                dataGridView1.Rows.Add(student.FirstName, student.LastName, birthDate);
            }
        }
    }
}
