using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScheduleOfTheDay.ViewModel;

namespace ScheduleOfTheDay.View
{
    /// <summary>
    /// Логика взаимодействия для DayScheduleView.xaml
    /// </summary>
    public partial class DayScheduleView : UserControl
    {
        public DayScheduleView()
        {
            InitializeComponent();
        }

        private void UserControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var viewmodel =(CellScheduleViewModel)DataContext;
            Button p = GetElementUnderMouse<Button>();
            if (p != null) 
            {
                if (e.LeftButton.ToString() == "Pressed")
                {
                    viewmodel.SetTrue(Convert.ToInt32(p.Content));
                    CellsListVIew.ItemsSource = null;
                    CellsListVIew.ItemsSource = viewmodel.ScheduleCells;
                }
                if (e.RightButton.ToString() == "Pressed")
                {
                    viewmodel.SetFalse(Convert.ToInt32(p.Content));
                    CellsListVIew.ItemsSource = null;
                    CellsListVIew.ItemsSource = viewmodel.ScheduleCells;
                }
            }
        }

        public static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                var correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        }
        public static T GetElementUnderMouse<T>() where T : UIElement
        {
            return FindVisualParent<T>(Mouse.DirectlyOver as UIElement);
        }
    }
}
