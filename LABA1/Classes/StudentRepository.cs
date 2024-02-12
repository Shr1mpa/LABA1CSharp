using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA1.Classes
{
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> students;
        public StudentRepository()
        {
            students = new List<Student>();
        }
        public List<Student> getStudents() { return students; }
       

        public void load(string fileName)
        {
            try
            {
                students.Clear();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("First Name:"))
                        {
                            string firstName = line.Split(':')[1].Trim();
                            line = sr.ReadLine(); // Read next line for Last Name
                            string lastName = line.Split(':')[1].Trim();
                            line = sr.ReadLine(); // Read next line for Date of Birth
                            string[] dobParts = line.Split(':')[1].Trim().Split('/');
                            int day = int.Parse(dobParts[0]);
                            int month = int.Parse(dobParts[1]);
                            int year = int.Parse(dobParts[2]);

                            // Створюємо новий об'єкт класу Student, використовуючи конструктор
                            Student student = new Student(firstName, lastName, day, month, year);
                            students.Add(student);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        public void save(Student student, string fileName)
        {
            students.Add(student);
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine("First Name: " + student.FirstName);
                    writer.WriteLine("Last Name: " + student.LastName);
                    writer.WriteLine("Date of Birth: " + student.Day + "/" + student.Month + "/" + student.Year);
                }
                Console.WriteLine("Student information has been saved to " + fileName);
                MessageBox.Show("Student added");

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while saving the student information: " + e.Message);
            }
        }
        
        public List<Student> sortStudentByMonth(int month)
        {
            var sortedStudents = students
            .Where(student => student.Month == month) 
            .OrderBy(student => student.Year) 
            .ThenBy(student => student.Day) 
            .ToList();

            return sortedStudents;
        }
    }
}
