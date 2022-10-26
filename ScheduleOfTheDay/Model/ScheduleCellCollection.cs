using System;
using System.Collections.Generic;
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

        string Path = Directory.GetCurrentDirectory() + "/SaveLog.txt";

        public List<ScheduleCell> LoadCollection()
        {
            if (File.Exists(Path))
            {
                StreamReader sr = new StreamReader(Path);
                DateTime time = new DateTime(2003,12,12);
                List<ScheduleCell> scheduleCells = new List<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    if ((i % 4) == 0 && i != 0)
                    {
                        scheduleCell.Separate = true;
                    }
                    string status = sr.ReadLine();
                    if (status == "True")
                    {
                        scheduleCell.IsSelect = true;
                    }
                    else
                    {
                        scheduleCell.IsSelect = false;
                    }
                    scheduleCells.Add(scheduleCell);
                }
                return scheduleCells;
            }
            else
            {
                DateTime time = new DateTime();
                List<ScheduleCell> scheduleCells = new List<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    scheduleCell.IsSelect = false;
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    scheduleCells.Add(scheduleCell);
                }
                return scheduleCells;
            }
        }
    }
}
