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
    /// Logika interakcji dla klasy DishView.xaml
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

        private async Task Load()
        {
                currentDish = await DishProcessor.LoadDish(DishID);
                LoadPage();
        }

        private void LoadPage()
        {
            titleLabel.Content = currentDish.Title;
            img.Source = new BitmapImage(new Uri(currentDish.Image));
            txtBlock.Text = currentDish.Instructions;
            txtNutrients.Text = currentDish.Nutrition.NutriInfoStringLong();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if(datePicker.SelectedDate != null)
            {
                Entry entry = new Entry(currentDish, new DateTime(datePicker.SelectedDate.Value.Ticks));
                datePicker.SelectedDate = null;
            }
        }
    }
}
