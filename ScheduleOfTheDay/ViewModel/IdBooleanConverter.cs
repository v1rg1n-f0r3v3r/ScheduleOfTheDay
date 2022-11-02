using System;
using System.Globalization;
using System.Windows.Data;

namespace ScheduleOfTheDay.ViewModel
{
    public class IdBooleanConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Convert.ToDouble(value) % 8) == 0 && Convert.ToDouble(value) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
