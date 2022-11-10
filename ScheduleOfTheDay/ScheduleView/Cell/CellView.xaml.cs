using ScheduleOfTheDay.ScheduleView.Cell;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ScheduleOfTheDay.View.Schedule.DayCells.Cell
{
    public partial class CellView : UserControl
    {
        public CellView()
        {
            InitializeComponent();
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            var viewmodel = (CelViewModel)DataContext;
            Label p = GetElementUnderMouse<Label>();
            if (p != null)
            {
                if (e.LeftButton.ToString() == "Pressed")
                {
                    if (p.Tag != null)
                    {
                        viewmodel.ChangeCellStatus(true);
                    }
                }
                if (e.RightButton.ToString() == "Pressed")
                {
                    if (p.Tag != null)
                    {
                        viewmodel.ChangeCellStatus(false);
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
