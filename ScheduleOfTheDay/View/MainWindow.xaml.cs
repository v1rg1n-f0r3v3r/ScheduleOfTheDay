using System.Windows;
using ScheduleOfTheDay.ViewModel;

namespace ScheduleOfTheDay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SheduleView.DataContext = new CellScheduleViewModel();
        }
    }
}
