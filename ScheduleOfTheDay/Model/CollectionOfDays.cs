using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOfTheDay.Model
{
    public class CollectionOfDays
    {
        public string Name { get; set; }
        public ObservableCollection<ScheduleCell> ScheduleCellsOfDay { get; set; }
    }
}
