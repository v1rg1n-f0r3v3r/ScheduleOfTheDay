using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ScheduleOfTheDay.ViewModel;

namespace ScheduleOfTheDay.Model
{
    public class DaysofWeekCollection: PropertyChange
    {
        int count = 0;
        public DaysofWeekCollection()
        {
            count = 96;
        }

        string Path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";

        public ObservableCollection<DaysOfWeek> LoadCollectionOfDays()
        {
            ObservableCollection<DaysOfWeek> collectionOfDays = new ObservableCollection<DaysOfWeek>();
            int i = 0;
            foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
            {
                DaysOfWeek collectionOfDay = new DaysOfWeek();
                collectionOfDay.DataContextOfTheDay = new DayCellViewModel(day);
                collectionOfDay.DayOfWeek = day;
                collectionOfDays.Add(collectionOfDay);
                i++;
            }
            return collectionOfDays;
        }

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
