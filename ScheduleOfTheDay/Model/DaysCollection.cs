using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ScheduleOfTheDay.ViewModel;

namespace ScheduleOfTheDay.Model
{
    public class DaysCollection: PropertyChange
    {
        int count = 0;
        public DaysCollection()
        {
            count = 96;
        }

        string Path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";

        public List<CollectionOfDays> LoadCollectionOfDays()
        {
            List<CollectionOfDays> collectionOfDays = new List<CollectionOfDays>();
            int i = 0;
            foreach (DayOfWeek day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
            {
                CollectionOfDays collectionOfDay = new CollectionOfDays();

                collectionOfDay.DayOfWeek = day;
                if (File.Exists(Path))
                {
                    collectionOfDay.ScheduleCellsOfDay = LoadCellsFromFile(day);
                }
                else
                {
                    collectionOfDay.ScheduleCellsOfDay = LoadCells(day);
                }
                collectionOfDays.Add(collectionOfDay);
                i++;
            }
            return collectionOfDays;
        }

        private ObservableCollection<ScheduleCell> LoadCellsFromFile(DayOfWeek dayOfWeek)
        {
            StreamReader sr = new StreamReader(Path);
            DateTime time = new DateTime();
            ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
            int i = 0;
            while (!sr.EndOfStream)
            {
                ScheduleCell scheduleCell = new ScheduleCell();
                time.AddMinutes(15);
                scheduleCell.NameOfWeek = dayOfWeek;
                scheduleCell.Time = time;
                scheduleCell.SequenceNumber = i;
                string status = sr.ReadLine();
                string[] statusWords = status.Split(' ');
                if (statusWords[0] == dayOfWeek.ToString())
                {
                    if (statusWords[1] == "True")
                    {
                        scheduleCell.IsSelect = true;
                    }
                    else
                    {
                        scheduleCell.IsSelect = false;
                    }
                    scheduleCells.Add(scheduleCell);
                    i++;
                }
            }
            return scheduleCells;
        }

        private ObservableCollection<ScheduleCell> LoadCells(DayOfWeek dayOfWeek)
        {
            DateTime time = new DateTime();
            ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
            for (int i = 0; i < count; i++)
            {
                ScheduleCell scheduleCell = new ScheduleCell();
                scheduleCell.SequenceNumber = i;
                scheduleCell.IsSelect = false;
                scheduleCell.NameOfWeek = dayOfWeek;
                time.AddMinutes(15);
                scheduleCell.Time = time;
                scheduleCells.Add(scheduleCell);
            }
            return scheduleCells;
        }
    }
}
