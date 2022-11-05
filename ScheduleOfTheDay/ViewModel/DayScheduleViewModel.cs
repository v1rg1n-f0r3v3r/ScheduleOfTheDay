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
            DaysofWeekCollection cellCollection = new DaysofWeekCollection();
            var list = cellCollection.LoadCollectionOfDays();
            _dayRows = new ObservableCollection<DaysOfWeek>(list);
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
        private ObservableCollection<DaysOfWeek> _dayRows;
        public ObservableCollection<DaysOfWeek> DayRows
        {
            get {return _dayRows; }
            set { _dayRows = value; }
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

        public void Save()
        {
            string path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";
            StreamWriter sw = new StreamWriter(path);
            foreach (var collections in DayRows)
            {
                var collection = DayRows.FirstOrDefault(x => x.DayOfWeek == collections.DayOfWeek);
                if (collection != null)
                {
                    DayCellViewModel dayCellViewModel = collection.DataContextOfTheDay;
                    foreach (var cellCollection in dayCellViewModel.CellSchedule)
                    {
                        sw.WriteLine(cellCollection.NameOfWeek.ToString() + " " + cellCollection.IsSelect);
                    }
                }
            }
            sw.Close();
            MessageBox.Show("DataSaved");
        }
    }
}
