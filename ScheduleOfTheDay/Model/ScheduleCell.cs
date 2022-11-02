using ScheduleOfTheDay.ViewModel;
using System;

namespace ScheduleOfTheDay.Model
{
    public class ScheduleCell: PropertyChange
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set 
            { 
                _id = value; 
                OnPropertyChanged(); 
            }
        }
        bool _isSelect;
        public bool IsSelect
        {
            get { return _isSelect; }
            set 
            { 
                _isSelect = value; 
                OnPropertyChanged();
            }
        }
        DateTime _time;
        public DateTime Time 
        {
            get { return _time; }
            set 
            {
                _time = value; 
                OnPropertyChanged(); 
            }
        }
        DayOfWeek _nameOfWeek;
        public DayOfWeek NameOfWeek 
        {
            get { return _nameOfWeek; }
            set 
            {
                _nameOfWeek = value; 
                OnPropertyChanged(); 
            }
        }
    }
}
