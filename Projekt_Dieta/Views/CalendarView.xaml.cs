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

namespace Projekt_Dieta.Views
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : Page
    {
        DateTime fromDate;

        public CalendarView()
        {
            InitializeComponent();
            fromDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            LabelUpdate();
        }

        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(-7);
            LabelUpdate();
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(7);
            LabelUpdate();

            AddEntryBlock();
        }

        private void AddEntryBlock()
        {
            Button remove = new Button();
            Button check = new Button();
            TextBlock textblock = new TextBlock();
            
            textblock.Text = "Schabowy";

            remove.Style = Resources["removeButton"] as Style;
            check.Style = Resources["checkButton"] as Style;

            remove.AddHandler(Button.ClickEvent, new RoutedEventHandler(Remove_Button_Click));

            DockPanel dock = new DockPanel();
            dock.Children.Add(textblock);
            dock.Children.Add(remove);
            dock.Children.Add(check);
            mondayStack.Children.Add(dock);
        }
        
        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            var parent = (UIElement)srcButton.Parent;
            parent.Visibility = Visibility.Collapsed;
        }


        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().Go_To_DishView();
        }

        private void LabelUpdate()
        {
            labelDate.Content = fromDate.ToString("dd.MM.yyyy") + " - " + fromDate.AddDays(6).ToString("dd.MM.yyyy");
        }

        private void RemoveAll()
        {
            mondayStack.Children.Clear();
            tuesdayStack.Children.Clear();
            wenesdayStack.Children.Clear();
            thursdayStack .Children.Clear();
            fridayStack.Children.Clear();
            saturdayStack.Children.Clear();
            sundayStack.Children.Clear();
        }
    }
}
