using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ScheduleOfTheDay.Model
{
    public class ScheduleCellCollection
    {
        int count = 0;
        public ScheduleCellCollection()
        {
            count = 96;
        }
        string Path = Directory.GetCurrentDirectory() + "/SaveLogAll.txt";

        public ObservableCollection<ScheduleCell> LoadCollection(CollectionOfDays.DayOfWeek dayOfWeek)
        {
            if (File.Exists(Path))
            {
                StreamReader sr = new StreamReader(Path);
                DateTime time = new DateTime(2003, 12, 12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                int i = 0;
                while (!sr.EndOfStream)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    time.AddMinutes(15);
                    scheduleCell.NameOfWeek = dayOfWeek;
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
                    {
                        scheduleCell.Separate = true;
                    }
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
            else
            {
                DateTime time = new DateTime();
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
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
}
