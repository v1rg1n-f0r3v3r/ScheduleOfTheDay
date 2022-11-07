using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScheduleOfTheDay.ViewModel
{
    public class PropertyChange: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
