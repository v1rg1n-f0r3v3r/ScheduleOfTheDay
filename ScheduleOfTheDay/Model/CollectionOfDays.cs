using ScheduleOfTheDay.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class CollectionOfDays
    {
        public DayOfWeek DayOfWeek { get; set; }
        public ObservableCollection<ScheduleCell> ScheduleCellsOfDay { get; set; }
    }
}
