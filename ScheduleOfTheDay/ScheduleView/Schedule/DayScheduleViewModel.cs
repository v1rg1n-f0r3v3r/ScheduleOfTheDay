using ScheduleOfTheDay.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using DayOfWeek = ScheduleOfTheDay.Model.DayOfWeek;

namespace ScheduleOfTheDay.ViewModel
{
    public class DayScheduleViewModel : PropertyChange
    {
        public DayScheduleViewModel()
        {
            var list = LoadCollectionOfDays();
            _dayRows = new ObservableCollection<DayCellsViewModel>(list);
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
        private ObservableCollection<DayCellsViewModel> _dayRows;
        public ObservableCollection<DayCellsViewModel> DayRows
        {
            get { return _dayRows; }
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
            StreamWriter sw = new StreamWriter(Path);
            foreach (var collections in DayRows)
            {
                var collection = DayRows.FirstOrDefault(x => x.NameOfDay == collections.NameOfDay);
                if (collection != null)
                {
                    foreach (var cellCollection in collection.CellSchedule)
                    {
                        sw.WriteLine(cellCollection.NameOfWeek.ToString() + " " + cellCollection.IsSelect);
                    }
                }
            }
            sw.Close();
            MessageBox.Show("DataSaved");
        }

        private ObservableCollection<DayCellsViewModel> LoadCollectionOfDays()
        {
            ObservableCollection<DayCellsViewModel> collectionOfDays = new ObservableCollection<DayCellsViewModel>();
            int i = 0;
            foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
            {
                DayCellsViewModel collectionOfDay = new DayCellsViewModel(day);
                collectionOfDays.Add(collectionOfDay);
                i++;
            }
            return collectionOfDays;
        }

        string Path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";
    }
}
