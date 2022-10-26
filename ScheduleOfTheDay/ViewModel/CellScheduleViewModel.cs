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
            ScheduleCellCollection cellCollectionM = new ScheduleCellCollection();
            var list = cellCollectionM.LoadCollectionMonday();
            ScheduleCellsM = new ObservableCollection<ScheduleCell>(list);
            ScheduleCellCollection cellCollectionT = new ScheduleCellCollection();
            var list1 = cellCollectionT.LoadCollectionTuesday();
            ScheduleCellsT = new ObservableCollection<ScheduleCell>(list1);
            ScheduleCellCollection cellCollectionW = new ScheduleCellCollection();
            var list2 = cellCollectionW.LoadCollectionWednsday();
            ScheduleCellsW = new ObservableCollection<ScheduleCell>(list2);
            ScheduleCellCollection cellCollectionTh = new ScheduleCellCollection();
            var list3 = cellCollectionTh.LoadCollectionThurday();
            ScheduleCellsTh = new ObservableCollection<ScheduleCell>(list3);
            ScheduleCellCollection cellCollectionF = new ScheduleCellCollection();
            var list4 = cellCollectionF.LoadCollectionFriday();
            ScheduleCellsF = new ObservableCollection<ScheduleCell>(list4);
            ScheduleCellCollection cellCollectionSa = new ScheduleCellCollection();
            var list5 = cellCollectionSa.LoadCollectionSaturday();
            ScheduleCellsSa = new ObservableCollection<ScheduleCell>(list5);
            ScheduleCellCollection cellCollectionSu = new ScheduleCellCollection();
            var list6 = cellCollectionSu.LoadCollectionSunday();
            ScheduleCellsSu = new ObservableCollection<ScheduleCell>(list6);
        }

        private ObservableCollection<ScheduleCell> _scheduleCellsM;
        public ObservableCollection<ScheduleCell> ScheduleCellsM
        {
            get { return _scheduleCellsM; }
            set { _scheduleCellsM = value; OnPropertyChanged();}
        }

        private ObservableCollection<ScheduleCell> _scheduleCellsT;
        public ObservableCollection<ScheduleCell> ScheduleCellsT
        {
            get { return _scheduleCellsT; }
            set { _scheduleCellsT = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ScheduleCell> _scheduleCellsW;
        public ObservableCollection<ScheduleCell> ScheduleCellsW
        {
            get { return _scheduleCellsW; }
            set { _scheduleCellsW = value; OnPropertyChanged(); }
        }


        private ObservableCollection<ScheduleCell> _scheduleCellsTh;
        public ObservableCollection<ScheduleCell> ScheduleCellsTh
        {
            get { return _scheduleCellsTh; }
            set { _scheduleCellsTh = value; OnPropertyChanged(); }
        }


        private ObservableCollection<ScheduleCell> _scheduleCellsF;
        public ObservableCollection<ScheduleCell> ScheduleCellsF
        {
            get { return _scheduleCellsF; }
            set { _scheduleCellsF = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ScheduleCell> _scheduleCellsSa;
        public ObservableCollection<ScheduleCell> ScheduleCellsSa
        {
            get { return _scheduleCellsSa; }
            set { _scheduleCellsSa = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ScheduleCell> _scheduleCellsSu;
        public ObservableCollection<ScheduleCell> ScheduleCellsSu
        {
            get { return _scheduleCellsSu; }
            set { _scheduleCellsSu = value; OnPropertyChanged(); }
        }

        public void SetTrue(int i, ObservableCollection<ScheduleCell> collection)
        {
            var cell = collection.FirstOrDefault(x => x.Id == i);
            if (cell != null) { cell.IsSelect = true; }
        }

        public void SetFalse(int i, ObservableCollection<ScheduleCell> collection)
        {
            var cell = collection.FirstOrDefault(x => x.Id == i);
            if (cell != null) { cell.IsSelect = false; }
        }
    }
}
