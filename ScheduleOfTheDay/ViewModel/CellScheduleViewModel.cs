using ScheduleOfTheDay.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
            set { _scheduleCells = value; OnPropertyChanged();}
        }

        public void SetTrue(int i)
        {
            var cell = ScheduleCells.FirstOrDefault(x => x.Id == i);
            if (cell != null) { cell.IsSelect = true; }
            OnPropertyChanged(nameof(cell));
        }

        public void SetFalse(int i)
        {
            var cell = ScheduleCells.FirstOrDefault(x => x.Id == i);
            if (cell != null) { cell.IsSelect = false; }
            OnPropertyChanged(nameof(cell));
        }
    }
}
