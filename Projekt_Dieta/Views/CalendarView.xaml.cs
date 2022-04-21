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
        }

        private void LabelUpdate()
        {
            labelDate.Content = fromDate.ToString("dd.MM.yyyy") + " - " + fromDate.AddDays(6).ToString("dd.MM.yyyy");
        }
    }
}
