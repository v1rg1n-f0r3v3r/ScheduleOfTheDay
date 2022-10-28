using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOfTheDay.Model
{
    public class CollectionOfDays
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

        public int Id { get; set; }
        public DayOfWeek Name { get; set; }
        public ObservableCollection<ScheduleCell> ScheduleCellsOfDay { get; set; }
    }
}
