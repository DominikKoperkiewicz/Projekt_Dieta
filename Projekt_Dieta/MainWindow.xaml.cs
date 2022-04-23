using Projekt_Dieta.API;
using Projekt_Dieta.Views;
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

namespace Projekt_Dieta
{
    /// <summary>
    /// Interaction logic for the MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            ActiveItem.Content = new MenuView();
        }
        /// <summary>
        /// Event handler responsible for making window dragable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        /// <summary>
        /// Event handler responsible for closing app after clicking "X" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Event handler responsible for changing view to MenuView after clicking Menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            ActiveItem.Content = new MenuView();
        }

        /// <summary>
        /// Event handler responsible for changing view to StatsView after clicking Stats button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stats_Button_Click(object sender, RoutedEventArgs e)
        {
            ActiveItem.Content = new StatsView();
        }

        /// <summary>
        /// Event handler responsible for changing view to CalendarView after clicking Calendar button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendar_Button_Click(object sender, RoutedEventArgs e)
        {
            ActiveItem.Content = new CalendarView();
        }

        /// <summary>
        /// Method thats change view to DishView showing dish with corresponding id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Go_To_DishView(int id)
        {
            DishView.DishID = id;
            ActiveItem.Content = new DishView();
        }
    }
}
