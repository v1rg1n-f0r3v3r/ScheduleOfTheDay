using System.Windows;
using ScheduleOfTheDay.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

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
