using ScheduleOfTheDay.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ScheduleOfTheDay.ViewModel
{
    public class DayScheduleViewModel : PropertyChange
    {
        public DayScheduleViewModel()
        {
            DaysofWeekCollection cellCollectionM = new DaysofWeekCollection();
            var list = cellCollectionM.LoadCollectionOfDays();
            _scheduleCells = new ObservableCollection<DaysOfWeek>(list);
            _saveCommand = new RelayCommand(obj => { Save(); });
            HeaderTime = GetTimeList();
        }
        private string[] GetTimeList()
        {
            DateTime time = DateTime.Parse("02:00:00 AM");
            string[] list = new string[13];
            for (int i = 0; i < 13; i++)
            {
                string listItem = time.ToString("HH:mm");
                time = time.AddHours(2);
                list[i] = listItem;
            }
            return list;
        }
        private ObservableCollection<DaysOfWeek> _scheduleCells;
        public ObservableCollection<DaysOfWeek> ScheduleCells
        {
            get {return _scheduleCells;}
            set { _scheduleCells = value; }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        private string[] _headerTime;
        public string[] HeaderTime
        {
            get { return _headerTime; }
            set { _headerTime = value; }
        }

        public void ChangeCellStatus(Model.DayOfWeek Name, int i, bool property)
        {
            var collection = ScheduleCells.FirstOrDefault(x => x.DayOfWeek == Name);
            if (collection != null)
            {
                var cell = collection.ScheduleCellsOfDay.FirstOrDefault(x => x.SequenceNumber == i);
                if (cell != null) { cell.IsSelect = property; }
            }
        }

        public void Save()
        {
            string path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";
            StreamWriter sw = new StreamWriter(path);
            foreach (var collections in ScheduleCells)
            {
                var collection = ScheduleCells.FirstOrDefault(x => x.DayOfWeek == collections.DayOfWeek);
                if (collection != null)
                {
                    foreach (var cur in collection.ScheduleCellsOfDay)
                    {
                        sw.WriteLine(cur.NameOfWeek.ToString() + " " + cur.IsSelect);
                    }
                }
            }
            sw.Close();
            MessageBox.Show("DataSaved");
        }
    }
}
