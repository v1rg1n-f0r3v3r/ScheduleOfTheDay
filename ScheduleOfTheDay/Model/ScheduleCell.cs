using ScheduleOfTheDay.ViewModel;
using System;

namespace ScheduleOfTheDay.Model
{
    public class ScheduleCell
    {
        public int Id { get; set; }
        public bool IsSelect { get; set; }
        public DateTime Time { get; set; }
        public DayOfWeek NameOfWeek { get; set; }
    }
}
