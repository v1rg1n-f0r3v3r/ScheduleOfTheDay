using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOfTheDay.Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using ScheduleOfTheDay.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GUISDK;

namespace ScheduleOfTheDay.ViewModel
{
    public class CellScheduleBehavior: Behavior<System.Windows.Controls.ListView>
    {
        Button button;
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += LoadedLV;
        }

        private void LoadedLV(object sender, EventArgs e)
        {
            button = AssociatedObject.FindChild<Button>();
            button.MouseRightButtonDown += CellClickRight;
            button.Click += CellClickLeft;
        }
        protected override void OnDetaching()
        {
            button.MouseRightButtonDown -= CellClickRight;
            button.Click -= CellClickLeft;
        }

        private void CellClickLeft(object sender, EventArgs e)
        {
            SetTrueCommand.Execute(null);
        }
        private void CellClickRight(object sender, EventArgs e)
        {
        }

        public ICommand SetTrueCommand
        {
            get { return (ICommand)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
           DependencyProperty.Register(nameof(SetTrueCommand), typeof(ICommand), typeof(CellScheduleBehavior), new PropertyMetadata(null));
    }
}
