using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleOfTheDay.Model;

namespace ScheduleOfTheDay.Model
{ 
    public class CollectionsOfDayCollection
    {
        public List<CollectionOfDays> LoadCollectionOfDays()
        {
            ScheduleCellCollection scheduleCellCollection = new ScheduleCellCollection();
            List<CollectionOfDays> collectionOfDays = new List<CollectionOfDays>();
            int i = 0;
            foreach (CollectionOfDays.DayOfWeek day in (CollectionOfDays.DayOfWeek[])Enum.GetValues(typeof(CollectionOfDays.DayOfWeek)))
            {
                CollectionOfDays collectionOfDay = new CollectionOfDays();
                collectionOfDay.Id = i;
                collectionOfDay.Name = day;
                collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollection(day);
                collectionOfDays.Add(collectionOfDay);
                i++;
            }
            return collectionOfDays;
        }
    }
}
