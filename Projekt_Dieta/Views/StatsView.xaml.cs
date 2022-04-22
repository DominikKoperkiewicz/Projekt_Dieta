using Projekt_Dieta.API;
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
    /// Interaction logic for StatsView.xaml
    /// </summary>
    public partial class StatsView : Page
    {
        DateTime fromDate;
        DateTime toDate;
        public StatsView()
        {
            fromDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            toDate = fromDate.AddDays(6);
            InitializeComponent();
            LabelUpdate();
            LoadWeeklyNutrients();
        }

        /// <summary>
        /// Changes displayed date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(-7);
            toDate = toDate.AddDays(-7);
            LabelUpdate();
            LoadWeeklyNutrients();
        }

        /// <summary>
        /// Changes displayed date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            fromDate = fromDate.AddDays(7);
            toDate = toDate.AddDays(7);
            LabelUpdate();
            LoadWeeklyNutrients();
        }

        /// <summary>
        /// Updates displayed date
        /// </summary>
        private void LabelUpdate()
        {
            TitleLabel.Content = fromDate.ToString("dd.MM.yyyy") + " - " + fromDate.AddDays(6).ToString("dd.MM.yyyy");
        }

        private void LoadWeeklyNutrients()
        {
            float Proteins = 0;
            float Fat = 0;
            float Carbs = 0;
            float Calories = 0;
            using (var context = new EntriesContext())
            {
                var query = context.Entries.Where(e => e.Date >= fromDate).Where(e => e.Date <= toDate);
                foreach (var entry in query)
                {
                    Proteins += entry.Protein;
                    Fat += entry.Fat;
                    Carbs += entry.Carbohydrates;
                    Calories += entry.Calories;
                }
            }
            CaloriesLabel.Content = Calories.ToString();
            FatLabel.Content = Fat.ToString();
            CarbsLabel.Content = Carbs.ToString();
            ProteinLabel.Content = Proteins.ToString();
        }
    }
}