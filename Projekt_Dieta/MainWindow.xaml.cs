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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            ActiveItem.Content = new MenuView();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            ActiveItem.Content = new MenuView();
        }

        private void Stats_Button_Click(object sender, RoutedEventArgs e)
        {
            ActiveItem.Content = new StatsView();
        }

        private void Calendar_Button_Click(object sender, RoutedEventArgs e)
        {
            ActiveItem.Content = new CalendarView();
        }
    }
}
