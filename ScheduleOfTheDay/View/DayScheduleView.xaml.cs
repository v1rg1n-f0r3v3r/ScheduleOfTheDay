using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ScheduleOfTheDay.ViewModel;
using DayOfWeek = ScheduleOfTheDay.Model.DayOfWeek;

namespace ScheduleOfTheDay.View
{
    public partial class DayScheduleView : UserControl
    {
        public DayScheduleView()
        {
            InitializeComponent();
        }
        private void UserControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var viewmodel = (DayScheduleViewModel)DataContext;
            Label p = GetElementUnderMouse<Label>();
            if (p != null) 
            { 
                if (e.LeftButton.ToString() == "Pressed")
                {
                    if (p.Tag != null)
                    {
                        viewmodel.FindParentTrue((DayOfWeek)p.Tag, Convert.ToInt32(p.Content));
                    }
                }
                if (e.RightButton.ToString() == "Pressed")
                {
                    if (p.Tag != null) 
                    {
                        viewmodel.FindParentFalse((DayOfWeek)p.Tag, Convert.ToInt32(p.Content));
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = (DayScheduleViewModel)DataContext;
            viewmodel.SaveCommand.Execute(null);
            MessageBox.Show("DataSaved");
        }
    }
}
