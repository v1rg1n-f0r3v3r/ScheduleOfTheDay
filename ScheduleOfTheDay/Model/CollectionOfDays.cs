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

    public class CollectionOfDays : PropertyChange
    {
        private DayOfWeek dayOfWeek;
        public DayOfWeek DayOfWeek 
        {
            get { return dayOfWeek; }
            set { dayOfWeek = value; OnPropertyChanged(); }
        }
        private ObservableCollection<ScheduleCell> scheduleCellsOfDay;
        public ObservableCollection<ScheduleCell> ScheduleCellsOfDay 
        { 
            get { return scheduleCellsOfDay; } 
            set { scheduleCellsOfDay = value; OnPropertyChanged();}
        }
    }
}
