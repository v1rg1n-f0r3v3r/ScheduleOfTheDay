using ScheduleOfTheDay.Model;
using System.Collections.ObjectModel;
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

        public void FindParentTrue(string Name, int i)
        {
            var collection = ScheduleCells.FirstOrDefault(x => x.Name == Name);
            if (collection != null)
            {
                var cell = collection.ScheduleCellsOfDay.FirstOrDefault(x => x.Id == i);
                if (cell != null) { cell.IsSelect = true; }
            }
        }

        public void FindAndSave(string Name, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            var collection = ScheduleCells.FirstOrDefault(x => x.Name == Name);
            if (collection != null)
            {
                foreach (var cur in collection.ScheduleCellsOfDay)
                {
                    sw.WriteLine(cur.IsSelect);
                }
                sw.Close();
            }
        }

        public void FindParentFalse(string Name, int i)
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
