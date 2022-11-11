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
        private readonly int count = 0;
        public DayCellsViewModel(DayOfWeek day)
        {
            NameOfDay = day;
            count = 96;
            CellSchedule = File.Exists(Global.Path) ? LoadCellsFromFile() : GenerateNewCells();
        }
        public DayOfWeek NameOfDay { get; }
        public ObservableCollection<CelViewModel> CellSchedule { get; }

        private ObservableCollection<CelViewModel> LoadCellsFromFile()
        {
            var sr = new StreamReader(Global.Path);
            var time = new DateTime(0);
            var scheduleCells = new ObservableCollection<CelViewModel>();
            var i = 0;
            while (!sr.EndOfStream)
            {
                var status = sr.ReadLine();
                var statusWords = status.Split(' ');
                if (statusWords[0] != NameOfDay.ToString()) continue;
                var isSelect = statusWords[1] == "True";
                var scheduleCell = new CelViewModel(i, NameOfDay, isSelect, time);
                time = time.AddMinutes(15);
                scheduleCells.Add(scheduleCell);
                i++;
            }
            return scheduleCells;
        }

        private ObservableCollection<CelViewModel> GenerateNewCells()
        {
            var time = new DateTime(0);
            var scheduleCells = new ObservableCollection<CelViewModel>();
            for (var i = 0; i < count; i++)
            {
                var scheduleCell = new CelViewModel(i, NameOfDay, false, time);
                time = time.AddMinutes(15);
                scheduleCells.Add(scheduleCell);
            }
            return scheduleCells;
        }
    }
}
