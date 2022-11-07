using ScheduleOfTheDay.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DayOfWeek = ScheduleOfTheDay.Model.DayOfWeek;

namespace ScheduleOfTheDay.ViewModel
{
    public class DayCellsViewModel: PropertyChange
    {
        int count = 0;
        public DayCellsViewModel(Model.DayOfWeek dayOfWeek)
        {
            count = 96;
            ObservableCollection<ScheduleCell> list;
            if (File.Exists(Directory.GetCurrentDirectory() + "/SaveLogAll.txt"))
            {
                list = LoadCellsFromFile(dayOfWeek);
            }
            else
            {
                list = GenerateNewCells(dayOfWeek);
            }
            _cellSchedule = new ObservableCollection<ScheduleCell>(list);
        }

        private ObservableCollection<ScheduleCell> _cellSchedule;
        public ObservableCollection<ScheduleCell> CellSchedule
        {
            get { return _cellSchedule; }
            set { _cellSchedule = value; }
        }

        public void ChangeCellStatus(int i, bool property)
        {
            var cell = CellSchedule.FirstOrDefault(x => x.SequenceNumber == i);
            if (cell != null) { cell.IsSelect = property; }
        }

        string Path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";

        public ObservableCollection<ScheduleCell> LoadCellsFromFile(DayOfWeek dayOfWeek)
        {
            StreamReader sr = new StreamReader(Path);
            DateTime time = DateTime.Parse("00:00:00 PM");
            ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
            int i = 0;
            while (!sr.EndOfStream)
            {
                ScheduleCell scheduleCell = new ScheduleCell();
                scheduleCell.NameOfWeek = dayOfWeek;
                scheduleCell.Time = time;
                time = time.AddMinutes(-15);
                scheduleCell.SequenceNumber = i;
                string status = sr.ReadLine();
                string[] statusWords = status.Split(' ');
                if (statusWords[0] == dayOfWeek.ToString())
                {
                    scheduleCell.IsSelect = statusWords[1] == "True";
                    scheduleCells.Add(scheduleCell);
                    i++;
                }
            }
            return scheduleCells;
        }

        public ObservableCollection<ScheduleCell> GenerateNewCells(DayOfWeek dayOfWeek)
        {
            DateTime time = DateTime.Parse("00:00:00 AM");
            ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
            for (int i = 0; i < count; i++)
            {
                ScheduleCell scheduleCell = new ScheduleCell();
                scheduleCell.SequenceNumber = i;
                scheduleCell.IsSelect = false;
                scheduleCell.NameOfWeek = dayOfWeek;
                scheduleCell.Time = time;
                time = time.AddMinutes(-15);
                scheduleCells.Add(scheduleCell);
            }
            return scheduleCells;
        }
    }
}
