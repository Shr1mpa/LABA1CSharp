using System;


namespace LABA1.Classes
{
    public class StudentVm
    {
        public StudentVm(String firstName, String lastName, int day, int month, int year)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            MonthVm mon = (MonthVm)Enum.ToObject(typeof(MonthVm), month);
            this.Birthday = new DataVm(day, mon, year);
        }

        public DataVm Birthday { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
     
    }
}
