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
}
