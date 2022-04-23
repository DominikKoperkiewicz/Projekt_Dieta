
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
        public string searchText;
        private List<DishSearchResult> list;

        public MenuView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method responsible for loading list of dishes
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private async Task LoadDishes(string query)
        {
            var dish = await DishProcessor.LoadDishes(query);
            list = dish.Results;
            foreach (var item in dish.Results)
            {
                item.UpdateNutriString();
                DataGridXAML.Items.Add(item);
            }
        }
        /// <summary>
        /// Event handler responsible for searching proper dishes after pressing 'Enter'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuView_EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                searchText = SearchBarTextBox.Text;

                DataGridXAML.Items.Clear();
                LoadDishes(searchText);
            }
        }
        /// <summary>
        /// Event handler responsible for changing view to proper DishView after double-clicking dish from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().Go_To_DishView(list[row.GetIndex()].Id);
        }

    }

}