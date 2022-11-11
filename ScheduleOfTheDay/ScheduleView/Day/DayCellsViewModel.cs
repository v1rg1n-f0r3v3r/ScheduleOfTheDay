using ScheduleOfTheDay.Helpers;
using ScheduleOfTheDay.ScheduleView.Cell;
using System;
using System.Collections.ObjectModel;
using System.IO;
using DayOfWeek = ScheduleOfTheDay.Model.DayOfWeek;

namespace ScheduleOfTheDay.ViewModel
{

    public class DayCellsViewModel : PropertyChange
    {
        int count = 0;
        public DayCellsViewModel(DayOfWeek day)
        {
            NameOfDay = day;
            count = 96;
            if (File.Exists(Global.Path))
            {
                CellSchedule = LoadCellsFromFile();
            }
            else
            {
                CellSchedule = GenerateNewCells();
            }
        }
        public DayOfWeek NameOfDay { get; }
        public ObservableCollection<CelViewModel> CellSchedule { get; }

        private ObservableCollection<CelViewModel> LoadCellsFromFile()
        {
            var sr = new StreamReader(Global.Path);
            var time = new DateTime(0);
            var scheduleCells = new ObservableCollection<CelViewModel>();
            int i = 0;
            while (!sr.EndOfStream)
            {
                var scheduleCell = new CelViewModel(i,NameOfDay);
                scheduleCell.Time = time;
                time = time.AddMinutes(15);
                string status = sr.ReadLine();
                string[] statusWords = status.Split(' ');
                if (statusWords[0] == NameOfDay.ToString())
                {
                    scheduleCell.IsSelect = statusWords[1] == "True";
                    scheduleCells.Add(scheduleCell);
                    i++;
                }
            }
            return scheduleCells;
        }

        private ObservableCollection<CelViewModel> GenerateNewCells()
        {
            var time = new DateTime(0);
            var scheduleCells = new ObservableCollection<CelViewModel>();
            for (int i = 0; i < count; i++)
            {
                var scheduleCell = new CelViewModel(i, NameOfDay);
                scheduleCell.Time = time;
                time = time.AddMinutes(15);
                scheduleCells.Add(scheduleCell);
            }
            return scheduleCells;
        }
    }
}
