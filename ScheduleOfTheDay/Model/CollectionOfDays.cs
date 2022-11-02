﻿using ScheduleOfTheDay.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace ScheduleOfTheDay.Model
{
    public enum DayOfWeek
    {
        [Description("Понедельник")]
        Monday,
        [Description("Вторник")]
        Tuesday,
        [Description("Среда")]
        Wennesday,
        [Description("Четверг")]
        Thursday,
        [Description("Пятница")]
        Friday,
        [Description("Суббота")]
        Saturday,
        [Description("Воскресенье")]
        Sunday
    }

    public class CollectionOfDays : PropertyChange
    {
        private DayOfWeek _dayOfWeek;
        public DayOfWeek DayOfWeek 
        {
            get { return _dayOfWeek; }
            set 
            { 
                _dayOfWeek = value; 
                OnPropertyChanged(); 
            }
        }
        private ObservableCollection<ScheduleCell> _scheduleCellsOfDay;
        public ObservableCollection<ScheduleCell> ScheduleCellsOfDay 
        { 
            get { return _scheduleCellsOfDay; } 
            set 
            { 
                _scheduleCellsOfDay = value; 
                OnPropertyChanged();
            }
        }
    }
}
