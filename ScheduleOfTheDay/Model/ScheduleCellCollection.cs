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

        string PathM = Directory.GetCurrentDirectory() + "/SaveLogM.txt";
        string PathT = Directory.GetCurrentDirectory() + "/SaveLogT.txt";
        string PathW = Directory.GetCurrentDirectory() + "/SaveLogW.txt";
        string PathTh = Directory.GetCurrentDirectory() + "/SaveLogTh.txt";
        string PathF = Directory.GetCurrentDirectory() + "/SaveLogF.txt";
        string PathSa = Directory.GetCurrentDirectory() + "/SaveLogSa.txt";
        string PathSu = Directory.GetCurrentDirectory() + "/SaveLogSu.txt";

        public ObservableCollection<ScheduleCell> LoadCollectionMonday()
        {
            if (File.Exists(PathM))
            {
                StreamReader sr = new StreamReader(PathM);
                DateTime time = new DateTime(2003,12,12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    time.AddMinutes(15);
                    scheduleCell.NameOfWeek = "Понедельник";
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
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
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
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

        public ObservableCollection<ScheduleCell> LoadCollectionTuesday()
        {
            if (File.Exists(PathT))
            {
                StreamReader sr = new StreamReader(PathT);
                DateTime time = new DateTime(2003, 12, 12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    scheduleCell.NameOfWeek = "Вторник";
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
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
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
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

        public ObservableCollection<ScheduleCell> LoadCollectionWednsday()
        {
            if (File.Exists(PathW))
            {
                StreamReader sr = new StreamReader(PathW);
                DateTime time = new DateTime(2003, 12, 12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    scheduleCell.NameOfWeek = "Среда";
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
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
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
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

        public ObservableCollection<ScheduleCell> LoadCollectionThurday()
        {
            if (File.Exists(PathTh))
            {
                StreamReader sr = new StreamReader(PathTh);
                DateTime time = new DateTime(2003, 12, 12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    scheduleCell.NameOfWeek = "Четверг";
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
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
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
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

        public ObservableCollection<ScheduleCell> LoadCollectionFriday()
        {
            if (File.Exists(PathF))
            {
                StreamReader sr = new StreamReader(PathF);
                DateTime time = new DateTime(2003, 12, 12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    scheduleCell.NameOfWeek = "Пятница";
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
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
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
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

        public ObservableCollection<ScheduleCell> LoadCollectionSaturday()
        {
            if (File.Exists(PathSa))
            {
                StreamReader sr = new StreamReader(PathSa);
                DateTime time = new DateTime(2003, 12, 12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    scheduleCell.NameOfWeek = "Суббота";
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
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
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
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

        public ObservableCollection<ScheduleCell> LoadCollectionSunday()
        {
            if (File.Exists(PathSu))
            {
                StreamReader sr = new StreamReader(PathSu);
                DateTime time = new DateTime(2003, 12, 12);
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
                for (int i = 0; i < count; i++)
                {
                    ScheduleCell scheduleCell = new ScheduleCell();
                    scheduleCell.Id = i;
                    scheduleCell.NameOfWeek = "Воскресенье";
                    time.AddMinutes(15);
                    scheduleCell.Time = time;
                    if ((i % 8) == 0 && i != 0)
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
                ObservableCollection<ScheduleCell> scheduleCells = new ObservableCollection<ScheduleCell>();
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
