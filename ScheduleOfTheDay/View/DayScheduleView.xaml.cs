using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using ScheduleOfTheDay.Model;
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
        string path;
        private void UserControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            DataGrid dataGrid = null;
            var viewmodel =(CellScheduleViewModel)DataContext;
            Button p = GetElementUnderMouse<Button>();
            if (p != null) 
            { 
                ObservableCollection<ScheduleCell> collection = null;
                if (p.Tag.ToString() == "Monday")
                {
                    collection = viewmodel.ScheduleCellsM;
                    path = Directory.GetCurrentDirectory() + "/SaveLogM.txt";
                    dataGrid = CellsListVIewM;
                }
                else
                if (p.Tag.ToString() == "Tuesday")
                {
                    path = Directory.GetCurrentDirectory() + "/SaveLogT.txt";
                    collection = viewmodel.ScheduleCellsT;
                    dataGrid = CellsListVIewT;
                }
                else
                if (p.Tag.ToString() == "Wendsday")
                {
                    path = Directory.GetCurrentDirectory() + "/SaveLogW.txt";
                    collection = viewmodel.ScheduleCellsW;
                    dataGrid = CellsListVIewW;
                }
                else
                if (p.Tag.ToString() == "Thursday")
                {
                    path = Directory.GetCurrentDirectory() + "/SaveLogTh.txt";
                    collection = viewmodel.ScheduleCellsTh;
                    dataGrid = CellsListVIewTh;
                }
                else
                if (p.Tag.ToString() == "Friday")
                {
                    path = Directory.GetCurrentDirectory() + "/SaveLogF.txt";
                    collection = viewmodel.ScheduleCellsF;
                    dataGrid = CellsListVIewF;
                }
                else
                if (p.Tag.ToString() == "Sanday")
                {
                    path = Directory.GetCurrentDirectory() + "/SaveLogSa.txt";
                    collection = viewmodel.ScheduleCellsSa;
                    dataGrid = CellsListVIewSa;
                }
                else
                if (p.Tag.ToString() == "Saturday")
                {
                    dataGrid = CellsListVIewSu;
                    path = Directory.GetCurrentDirectory() + "/SaveLogSu.txt";
                    collection = viewmodel.ScheduleCellsSu;
                }
                if (e.LeftButton.ToString() == "Pressed")
                {
                    viewmodel.SetTrue(Convert.ToInt32(p.Content), collection);
                }
                if (e.RightButton.ToString() == "Pressed")
                {
                    viewmodel.SetFalse(Convert.ToInt32(p.Content), collection);
                }
                SaveStatus(collection);
                Refresh(dataGrid, collection);
            }
        }

        public void Refresh(DataGrid dataGrid, ObservableCollection<ScheduleCell> collection)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = collection;
        }

        public void SaveStatus(ObservableCollection<ScheduleCell> collection)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (var cur in collection)
            {
                sw.WriteLine(cur.IsSelect);
            }
            sw.Close();
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
