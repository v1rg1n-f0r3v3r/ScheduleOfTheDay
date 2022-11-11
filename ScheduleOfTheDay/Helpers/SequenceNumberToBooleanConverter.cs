using System;
using System.Globalization;
using System.Windows.Data;

namespace ScheduleOfTheDay.ViewModel
{
    public class SequenceNumberToBooleanConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Convert.ToDouble(value) % 8) == 0 && Convert.ToDouble(value) != 0;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
