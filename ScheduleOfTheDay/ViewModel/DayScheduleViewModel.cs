using ScheduleOfTheDay.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ScheduleOfTheDay.ViewModel
{
    public class DayScheduleViewModel : PropertyChange
    {
        public DayScheduleViewModel()
        {
            DaysCollection cellCollectionM = new DaysCollection();
            var list = cellCollectionM.LoadCollectionOfDays();
            _scheduleCells = new ObservableCollection<CollectionOfDays>(list);
            var time = GetTimeList();
            Time = time;
        }
        private string[] GetTimeList()
        {
            string[] list = { "02:00", "04:00", "06:00", "08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00", "00:00" };
            return list;
        }
        private ObservableCollection<CollectionOfDays> _scheduleCells;
        public ObservableCollection<CollectionOfDays> ScheduleCells
        {
            get {return _scheduleCells;}
            set { _scheduleCells = value; }
        }

        private string[] _time;
        public string[] Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public void FindParentTrue(DayOfWeek Name, int i)
        {
            var collection = ScheduleCells.FirstOrDefault(x => x.DayOfWeek == Name);
            if (collection != null)
            {
                var cell = collection.ScheduleCellsOfDay.FirstOrDefault(x => x.Id == i);
                if (cell != null) { cell.IsSelect = true;}
            }
        }

        public void FindParentFalse(DayOfWeek Name, int i)
        {
            var collection = ScheduleCells.FirstOrDefault(x => x.DayOfWeek == Name);
            if (collection != null) 
            {
                var cell = collection.ScheduleCellsOfDay.FirstOrDefault(x => x.Id == i);
                if (cell != null) { cell.IsSelect = false; }
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
        }
    }
}
