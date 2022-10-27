using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleOfTheDay.Model
{ 
    public class CollectionsOfDayCollection
    {
        public List<CollectionOfDays> LoadCollectionOfDays()
        {
            ScheduleCellCollection scheduleCellCollection = new ScheduleCellCollection();
            List<CollectionOfDays> collectionOfDays = new List<CollectionOfDays>();
            for (int i = 0; i < 7; i++)
            {
                CollectionOfDays collectionOfDay = new CollectionOfDays();
                if (i == 0)
                {
                    collectionOfDay.Name = "Понедельник";
                    collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollectionMonday();
                    collectionOfDays.Add(collectionOfDay);
                }
                else
                if (i == 1)
                {
                    collectionOfDay.Name = "Вторник";
                    collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollectionTuesday();
                    collectionOfDays.Add(collectionOfDay);
                }
                else
                if (i == 2)
                {
                    collectionOfDay.Name = "Среда";
                    collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollectionWednsday();
                    collectionOfDays.Add(collectionOfDay);
                }
                else
                if (i == 3)
                {
                    collectionOfDay.Name = "Четверг";
                    collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollectionThurday();
                    collectionOfDays.Add(collectionOfDay);
                }
                else
                if (i == 4)
                {
                    collectionOfDay.Name = "Пятница";
                    collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollectionFriday();
                    collectionOfDays.Add(collectionOfDay);
                }
                else
                if (i == 5)
                {
                    collectionOfDay.Name = "Суббота";
                    collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollectionSaturday();
                    collectionOfDays.Add(collectionOfDay);
                }
                else
                if (i == 6)
                {
                    collectionOfDay.Name = "Воскресенье";
                    collectionOfDay.ScheduleCellsOfDay = scheduleCellCollection.LoadCollectionSunday();
                    collectionOfDays.Add(collectionOfDay);
                }
            }
            return collectionOfDays;
        }
    }
}
