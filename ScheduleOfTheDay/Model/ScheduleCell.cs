using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOfTheDay.Model
{
    public class ScheduleCell
    {
        public int Id { get; set; }
        public bool IsSelect { get; set; }
        public DateTime Time { get; set; }
        public bool Separate { get; set; }
    }
}
