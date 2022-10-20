using ScheduleOfTheDay.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ScheduleOfTheDay.ViewModel
{
    public class CellScheduleViewModel: PropertyChange
    {
        public CellScheduleViewModel()
        {
            ScheduleCellCollection cellCollection = new ScheduleCellCollection();
            var list = cellCollection.LoadCollection();
            ScheduleCells = new ObservableCollection<ScheduleCell>(list);
        }

        private ObservableCollection<ScheduleCell> _scheduleCells;
        public ObservableCollection<ScheduleCell> ScheduleCells
        {
            get { return _scheduleCells; }
            set { _scheduleCells = value; }
        }
    }
}
