using ScheduleOfTheDay.Helpers;
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
            Days = new ObservableCollection<DayCellsViewModel>(list);
            SaveCommand = new RelayCommand(obj => { Save(); });
            HeaderTime = GetTimeList();
        }

        public RelayCommand SaveCommand { get; }
        private string[] GetTimeList()
        {
            var time = DateTime.Parse("02:00:00 AM");
            var listOfTimeHeader = new string[13];
            for (int i = 0; i < 13; i++)
            {
                string listItem = time.ToString("HH:mm");
                time = time.AddHours(2);
                listOfTimeHeader[i] = listItem;
            }
            return listOfTimeHeader;
        }

        public ObservableCollection<DayCellsViewModel> Days { get;}

        public string[] HeaderTime { get; }

        private void Save()
        {
            var sw = new StreamWriter(Global.Path);
            foreach (var day in Days)
            {
                var collection = Days.FirstOrDefault(x => x.NameOfDay == day.NameOfDay);
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
    }
}
