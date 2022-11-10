using ScheduleOfTheDay.Model;
using ScheduleOfTheDay.ScheduleView.Cell;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DayOfWeek = ScheduleOfTheDay.Model.DayOfWeek;

namespace ScheduleOfTheDay.ViewModel
{
    public class DayCellsViewModel : PropertyChange
    {
        int count = 0;
        public DayCellsViewModel(DayOfWeek day)
        {
            count = 96;
            if (File.Exists(Path))
            {
                CellSchedule = LoadCellsFromFile(day);
            }
            else
            {
                CellSchedule = GenerateNewCells(day);
            }
            NameOfDay = day;
        }

        private DayOfWeek _dayOfWeek;
        public DayOfWeek NameOfDay
        {
            get { return _dayOfWeek; }
            set { _dayOfWeek = value; }
        }

        private ObservableCollection<CelViewModel> _cellSchedule;
        public ObservableCollection<CelViewModel> CellSchedule
        {
            get { return _cellSchedule; }
            set { _cellSchedule = value; }
        }

        string Path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";

        private ObservableCollection<CelViewModel> LoadCellsFromFile(DayOfWeek dayOfWeek)
        {
            var sr = new StreamReader(Path);
            var time = DateTime.Parse("00:00:00 PM");
            var scheduleCells = new ObservableCollection<CelViewModel>();
            int i = 0;
            while (!sr.EndOfStream)
            {
                var scheduleCell = new CelViewModel(i,dayOfWeek);
                scheduleCell.Time = time;
                time = time.AddMinutes(-15);
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

        private ObservableCollection<CelViewModel> GenerateNewCells(DayOfWeek dayOfWeek)
        {
            var time = DateTime.Parse("00:00:00 AM");
            var scheduleCells = new ObservableCollection<CelViewModel>();
            for (int i = 0; i < count; i++)
            {
                var scheduleCell = new CelViewModel(i,dayOfWeek);
                scheduleCell.IsSelect = false;
                scheduleCell.Time = time;
                time = time.AddMinutes(-15);
                scheduleCells.Add(scheduleCell);
            }
            return scheduleCells;
        }
    }
}
