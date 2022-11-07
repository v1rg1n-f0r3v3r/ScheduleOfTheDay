using ScheduleOfTheDay.ViewModel;
using System;
using DayOfWeek = ScheduleOfTheDay.Model.DayOfWeek;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ScheduleOfTheDay.View
{
    /// <summary>
    /// Логика взаимодействия для DayView.xaml
    /// </summary>
    public partial class DayView : UserControl
    {
        public DayView()
        {
            InitializeComponent();
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            var viewmodel = (DayCellsViewModel)DataContext;
            Label p = GetElementUnderMouse<Label>();
            if (p != null)
            {
                if (e.LeftButton.ToString() == "Pressed")
                {
                    if (p.Tag != null)
                    {
                        viewmodel.ChangeCellStatus(Convert.ToInt32(p.Content), true);
                    }
                }
                if (e.RightButton.ToString() == "Pressed")
                {
                    if (p.Tag != null)
                    {
                        viewmodel.ChangeCellStatus(Convert.ToInt32(p.Content), false);
                    }
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
