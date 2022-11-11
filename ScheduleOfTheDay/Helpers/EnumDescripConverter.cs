using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace ScheduleOfTheDay.ViewModel
{
    public class EnumDescripConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var myEnum = (Enum)value;
            var description = GetEnumDescription(myEnum);
            return description;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        private string GetEnumDescription(Enum enumObj)
        {
            var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            return fieldInfo.GetCustomAttributes(false).Length == 0 ? enumObj.ToString() : ((DescriptionAttribute)fieldInfo.GetCustomAttributes(false)[0]).Description;
        }
    }
}