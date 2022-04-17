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
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : Page
    {

        public MenuView()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Loads dish using it's id and displays it in a test label
        /// </summary>
        /// <param name="dish_id"></param> dish ID used by api
        /// <returns></returns>
        private async Task LoadDish(int dish_id)
        {
            var dish = await DishProcessor.LoadDish(dish_id);

            test_label.Content = dish.Title + " " + dish.Nutrition.NutriInfoString() + "\n" + dish.SpoonacularSourceUrl + "\n" + dish.Instructions;

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Makes sure all the info gets loaded onto the page
            await LoadDish(715538);
        }
    }

}
