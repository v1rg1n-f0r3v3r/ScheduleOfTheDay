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
            DaysCollection = new ObservableCollection<DayCellsViewModel>(list);
            SaveCommand = new RelayCommand(obj => { Save(); });
            HeaderTime = GetTimeList();
        }

        public RelayCommand SaveCommand { get; }
        private string[] GetTimeList()
        {
            var time = DateTime.Parse("02:00:00 AM");
            string[] list = new string[13];
            for (int i = 0; i < 13; i++)
            {
                string listItem = time.ToString("HH:mm");
                time = time.AddHours(2);
                list[i] = listItem;
            }
            return list;
        }

        public ObservableCollection<DayCellsViewModel> DaysCollection { get; set; }

        private string[] _headerTime;
        public string[] HeaderTime
        {
            get { return _headerTime; }
            set { _headerTime = value; }
        }

        public void Save()
        {
            var sw = new StreamWriter(Path);
            foreach (var collections in DaysCollection)
            {
                var collection = DaysCollection.FirstOrDefault(x => x.NameOfDay == collections.NameOfDay);
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
            var collectionOfDays = new ObservableCollection<DayCellsViewModel>();
            foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
            {
                var collectionOfDay = new DayCellsViewModel(day);
                collectionOfDays.Add(collectionOfDay);
            }
            return collectionOfDays;
        }

        string Path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";
    }
}
