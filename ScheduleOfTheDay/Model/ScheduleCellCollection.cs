using System.Collections.Generic;

namespace ScheduleOfTheDay.Model
{
    public class ScheduleCellCollection
    {
        int count = 0;
        public ScheduleCellCollection()
        {
            count = 8;
        }

        public List<ScheduleCell> LoadCollection()
        {
            List<ScheduleCell> scheduleCells = new List<ScheduleCell>();
            for (int i = 1; i < count; i++)
            {
                ScheduleCell scheduleCell = new ScheduleCell();
                scheduleCell.Id = i;
                scheduleCell.IsSelect = false;
                if (i == 5) { scheduleCell.IsSelect = true; }
                scheduleCells.Add(scheduleCell);
            }
            return scheduleCells;
        }
    }
}
