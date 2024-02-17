using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LABA1.Classes
{
    public class FileManager
    {
        
        private static string _filename = "D:\\C#Labs\\LABA1\\LABA1\\Students.json";
       public List<StudentVm> Students { get; set; }
        public FileManager()
        {
           Students = new List<StudentVm>();
            this.Load();
        }
       
        public void Load()
        {
            Students.Clear();
            try
            {
                string json = File.ReadAllText(_filename);
                Students =  JsonConvert.DeserializeObject<List<StudentVm>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                Students =  new List<StudentVm>(); 
            }
        }

        public void Save(StudentVm student)
        {
           
            Students.Add(student);
            try
            {
                string json = JsonConvert.SerializeObject(Students, Formatting.Indented);
                File.WriteAllText(_filename, json);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while saving the student information: " + e.Message);
            }
        }
       

      
    }
}
