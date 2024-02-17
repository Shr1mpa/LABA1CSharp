

namespace LABA1.Classes
{
    public class DataVm
    {
        public DataVm(int day, MonthVm month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public int Day { get; set; }
      
        public MonthVm Month { get; set; }
       
        public int Year { get; set; } 
        
    }
}
