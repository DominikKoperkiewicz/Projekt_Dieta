using Projekt_Dieta.DataAccess;
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
        DateTime toDate;
        List<Label> labels = new List<Label>();

        public CalendarView()
        {
            InitializeComponent();
            fromDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            toDate = fromDate.AddDays(6);
            LabelUpdate();
            LoadCurrentWeeksMenu();
        }

        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(-7);
            toDate = toDate.AddDays(-7);
            foreach (Label label in labels)
            {
                WeeksGrid.Children.Remove(label);
            }
            labels.Clear();
            LabelUpdate();
            LoadCurrentWeeksMenu();
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(7);
            toDate = toDate.AddDays(7);
            foreach (Label label in labels)
            {
                WeeksGrid.Children.Remove(label);
            }
            labels.Clear();
            LabelUpdate();
            LoadCurrentWeeksMenu();
        }

        private void LabelUpdate()
        {
            labelDate.Content = fromDate.ToString("dd.MM.yyyy") + " - " + fromDate.AddDays(6).ToString("dd.MM.yyyy");
        }

        private void LoadCurrentWeeksMenu()
        {
            DateTime test_date = fromDate.AddDays(1);
            int[] Weeks = new int[7];
            using (var context = new EntriesContext())
            {
                var query = context.Entries.Where(e => e.Date >= fromDate).Where(e => e.Date <= toDate);
                foreach (var entry in query)
                {
                    Label label = new Label();
                    label.SetValue(Grid.ColumnProperty, (int)entry.Date.DayOfWeek); // dayofweek 0 - niedziela, trzeba to dopracowac bo zamienia poniedzialek z niedzielą
                    label.SetValue(Grid.RowProperty, 1+Weeks[(int)entry.Date.DayOfWeek]);
                    label.Content = entry.Title;
                    WeeksGrid.Children.Add(label);
                    labels.Add(label);
                    Weeks[(int)entry.Date.DayOfWeek]++;
                }
            }
        }
        
    }
}
