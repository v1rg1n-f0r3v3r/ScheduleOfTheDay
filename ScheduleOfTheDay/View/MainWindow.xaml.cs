using System.Windows;
using ScheduleOfTheDay.ViewModel;

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
