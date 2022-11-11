using ScheduleOfTheDay.ViewModel;
using System.Windows;

namespace ScheduleOfTheDay
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SheduleView.DataContext = new DayScheduleViewModel();
        }
    }
}
