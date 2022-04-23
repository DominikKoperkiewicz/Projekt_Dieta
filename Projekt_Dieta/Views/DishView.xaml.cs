using Projekt_Dieta.API;
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
    /// Interaction logic for DishView.xaml
    /// </summary>
    public partial class DishView : Page
    {
        public static int DishID;
        private Dish currentDish;

        public DishView()
        {
            InitializeComponent();
            Load();

        }
        /// <summary>
        /// Method responsible for loading single dish with corresponding id
        /// </summary>
        /// <returns></returns>
        private async Task Load()
        {
                currentDish = await DishProcessor.LoadDish(DishID);
                LoadPage();
        }
        /// <summary>
        /// Method responsible for setting displayed content to proper dish 
        /// </summary>
        private void LoadPage()
        {
            titleLabel.Content = currentDish.Title;
            img.Source = new BitmapImage(new Uri(currentDish.Image));
            txtBlock.Text = "URL: " + currentDish.SpoonacularSourceUrl+ "\n" + currentDish.Instructions;
            txtNutrients.Text = currentDish.Nutrition.NutriInfoStringLong();
            NutrientsLabel.Content = $"Nutrients in {currentDish.Servings} servings";
        }
        /// <summary>
        /// Event handler responsible for adding new entry to database after clicking 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if(datePicker.SelectedDate != null)
            {
                Entry entry = new Entry(currentDish, new DateTime(datePicker.SelectedDate.Value.Ticks));
                AddNewEntry(entry);
                datePicker.SelectedDate = null;
            }
        }
        /// <summary>
        /// Method responsible for adding new entry to database
        /// </summary>
        /// <param name="entry"></param>
        private void AddNewEntry(Entry entry)
        {
            using (var context = new EntriesContext())
            {
                context.Entries.Add(entry);
                context.SaveChanges();
            }
        }
    }
}
