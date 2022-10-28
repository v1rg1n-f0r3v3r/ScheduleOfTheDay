using ScheduleOfTheDay.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ScheduleOfTheDay.ViewModel
{
    public class CellScheduleViewModel : PropertyChange
    {
        public CellScheduleViewModel()
        {
            CollectionsOfDayCollection cellCollectionM = new CollectionsOfDayCollection();
            var list = cellCollectionM.LoadCollectionOfDays();
            ScheduleCells = new ObservableCollection<CollectionOfDays>(list);
        }

        private ObservableCollection<CollectionOfDays> _scheduleCells;
        public ObservableCollection<CollectionOfDays> ScheduleCells
        {
            get { return _scheduleCells; }
            set { _scheduleCells = value; }
        }

        public void FindParentTrue(CollectionOfDays.DayOfWeek Name, int i)
        {
            var collection = ScheduleCells.FirstOrDefault(x => x.Name == Name);
            if (collection != null)
            {
                var cell = collection.ScheduleCellsOfDay.FirstOrDefault(x => x.Id == i);
                if (cell != null) { cell.IsSelect = true; }
            }
        }

        public void Save()
        {
            string path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < ScheduleCells.Count; i++)
            {
                var collection = ScheduleCells.FirstOrDefault(x => x.Id == i);
                if (collection != null)
                {
                    int count = 0;
                    foreach (var cur in collection.ScheduleCellsOfDay)
                    {
                        sw.WriteLine(cur.NameOfWeek.ToString() + " " + cur.IsSelect);
                        count++;
                    }
                }
            }
            sw.Close();
        }

        public void FindParentFalse(CollectionOfDays.DayOfWeek Name, int i)
        {
            var collection = ScheduleCells.FirstOrDefault(x => x.Name == Name);
            if (collection != null) 
            {
                var cell = collection.ScheduleCellsOfDay.FirstOrDefault(x => x.Id == i);
                if (cell != null) { cell.IsSelect = false; }
            }
        }
    }
}
