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

namespace ScheduleOfTheDay.ViewModel
{
    public class CellScheduleBehavior: Behavior<System.Windows.Controls.Button>
    {

        protected override void OnAttached()
        {
            AssociatedObject.MouseRightButtonDown += CellClickRight;
            AssociatedObject.Click += CellClickLeft;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseRightButtonDown -= CellClickRight;
            AssociatedObject.MouseLeftButtonUp -= CellClickLeft;
        }

        private void CellClickLeft(object sender, EventArgs e)
        {
        }
        private void CellClickRight(object sender, EventArgs e)
        {
        }
    }
}
