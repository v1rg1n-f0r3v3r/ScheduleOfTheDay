using ScheduleOfTheDay.ViewModel;
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

    public class DaysOfWeek : PropertyChange
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

        private DayCellsViewModel _dataContextOfTheDay;
        public DayCellsViewModel DataContextOfTheDay
        {
            get { return _dataContextOfTheDay; }
            set
            {
                _dataContextOfTheDay = value;
                OnPropertyChanged();
            }
        }
    }
}
