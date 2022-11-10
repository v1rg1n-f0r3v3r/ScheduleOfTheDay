using ScheduleOfTheDay.ScheduleView.Cell;
using System.Data.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace ScheduleOfTheDay.ViewModel
{
    public class BehaviorOfDaysCells: Behavior<System.Windows.Controls.Label>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += UserControl_MouseMove;
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            var viewmodel = (CelViewModel)AssociatedObject.DataContext;
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

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= UserControl_MouseMove;
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
