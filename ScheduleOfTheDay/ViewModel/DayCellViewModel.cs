using ScheduleOfTheDay.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOfTheDay.ViewModel
{
    public class DayCellViewModel: PropertyChange
    {
        public DayCellViewModel(Model.DayOfWeek dayOfWeek)
        {
            DaysofWeekCollection cellCollection = new DaysofWeekCollection();
            ObservableCollection<ScheduleCell> list;
            if (File.Exists(Directory.GetCurrentDirectory() + "/SaveLogAll.txt"))
            {
                list = cellCollection.LoadCellsFromFile(dayOfWeek);
            }
            else
            {
                list = cellCollection.GenerateNewCells(dayOfWeek);
            }
            _cellSchedule = new ObservableCollection<ScheduleCell>(list);
        }

        private ObservableCollection<ScheduleCell> _cellSchedule;
        public ObservableCollection<ScheduleCell> CellSchedule
        {
            get { return _cellSchedule; }
            set { _cellSchedule = value; }
        }

        public void ChangeCellStatus(int i, bool property)
        {
            var cell = CellSchedule.FirstOrDefault(x => x.SequenceNumber == i);
            if (cell != null) { cell.IsSelect = property; }
        }
    }
}
