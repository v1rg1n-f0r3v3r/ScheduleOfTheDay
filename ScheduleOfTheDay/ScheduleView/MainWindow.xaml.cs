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

        public static IEnumerable<T> FindVisualChilds<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChilds<T>(ithChild)) yield return childOfChild;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Model.DayOfWeek dayOfWeek = 0;
            foreach (UserControl tb in FindVisualChilds<UserControl>(SheduleView))
            {
                tb.DataContext = new DayCellsViewModel(dayOfWeek);
                dayOfWeek++;
            }
        }
    }
}
