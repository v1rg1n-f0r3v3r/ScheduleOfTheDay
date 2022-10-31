using ScheduleOfTheDay.ViewModel;
using System;

namespace ScheduleOfTheDay.Model
{
    public class ScheduleCell: PropertyChange
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }
        bool isSelect;
        public bool IsSelect
        {
            get { return isSelect; }
            set { isSelect = value; OnPropertyChanged(); }
        }
        DateTime time;
        public DateTime Time 
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }
        DayOfWeek nameOfWeek;
        public DayOfWeek NameOfWeek 
        {
            get { return nameOfWeek; }
            set { nameOfWeek = value; OnPropertyChanged(); }
        }
    }
}
