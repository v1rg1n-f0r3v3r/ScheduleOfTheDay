using ScheduleOfTheDay.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ScheduleOfTheDay.ViewModel
{
    public class CellScheduleViewModel: PropertyChange
    {
        public CellScheduleViewModel()
        {
            _setTrue = new RelayCommand(obj => { SetTrue();});
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

        private void SetTrue(int i)
        {
            var cell = ScheduleCells.FirstOrDefault(x => x.Id == i);
            if (cell != null) { cell.IsSelect = true; }
        }

        private RelayCommand _setTrue;
        public RelayCommand setTrue
        {
            get { return _setTrue; }
        }
    }
}
