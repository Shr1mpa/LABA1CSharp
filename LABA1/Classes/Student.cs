using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA1.Classes
{
    public class Student
    {
        private String firstName { get; set; }
        private String lastName { get; set; }
        private int day { get; set; }
        private int month { get; set; }
        private int year { get; set; }


        public Student(String firstName, String lastName, int day, int month, int year)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

    }
}
