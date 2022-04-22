using Projekt_Dieta.DataAccess;
using Projekt_Dieta.Models;
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

        EntriesContext context = new EntriesContext();

        public CalendarView()
        {
            InitializeComponent();
            fromDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            toDate = fromDate.AddDays(6);
            LabelUpdate();
            GenerateEntryBlocks();
        }

        /// <summary>
        /// Changes displayed date, clears all blocks and generates new ones for previous week.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(-7);
            toDate = toDate.AddDays(-7);

            RemoveAll();
            LabelUpdate();
            GenerateEntryBlocks();
        }

        /// <summary>
        /// Changes displayed date, clears all blocks and generates new ones for next week.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(7);
            toDate = toDate.AddDays(7);

            RemoveAll();
            LabelUpdate();
            GenerateEntryBlocks();
        }

        /// <summary>
        /// Updates displayed date
        /// </summary>
        private void LabelUpdate()
        {
            labelDate.Content = fromDate.ToString("dd.MM.yyyy") + " - " + fromDate.AddDays(6).ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// Generates all entries blocks for current week based on database context
        /// </summary>
        private void GenerateEntryBlocks()
        {
            StackPanel[] Panels = new StackPanel[] { sundayStack, mondayStack, tuesdayStack, wenesdayStack, thursdayStack, fridayStack, saturdayStack };
            int i = 0;

            var query = context.Entries.Where(e => e.Date >= fromDate).Where(e => e.Date <= toDate);

            foreach (var entry in query)
            {
                Button remove = new Button();
                Button check = new Button();
                TextBlock textblock = new TextBlock();

                textblock.Text = entry.Title;

                remove.Style = Resources["removeButton"] as Style;
                check.Style = Resources["checkButton"] as Style;

                remove.Click += (s, e) =>
                {
                    Remove_Button_Click(s, e);
                    context.Entries.Remove(entry);
                    context.SaveChanges();
                };
                check.Click += (s, e) =>
                {
                    Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().Go_To_DishView(entry.DishID);
                };

                DockPanel dock = new DockPanel();
                dock.Children.Add(textblock);
                dock.Children.Add(remove);
                dock.Children.Add(check);

                i = (int)entry.Date.DayOfWeek;
                Panels[i].Children.Add(dock);
            }
        }
        /// <summary>
        /// Removes deleted blocks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            var parent = (UIElement)srcButton.Parent;
            parent.Visibility = Visibility.Collapsed;
        }

        private void RemoveAll()
        {
            mondayStack.Children.Clear();
            tuesdayStack.Children.Clear();
            wenesdayStack.Children.Clear();
            thursdayStack.Children.Clear();
            fridayStack.Children.Clear();
            saturdayStack.Children.Clear();
            sundayStack.Children.Clear();
        }
    }
}
