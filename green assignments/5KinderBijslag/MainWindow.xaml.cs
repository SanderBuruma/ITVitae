using System;
using System.Collections.Generic;
using System.IO;
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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace _5KinderBijslag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data DataPage = new Data();
        private Result ResultPage = new Result();
        private UserControl[] Views;
        public MainWindow()
        {
            InitializeComponent();

            Views = new UserControl[2]
            {
                DataPage,
                ResultPage
            };

            MainFrame.NavigationService.Navigate(Views[0]);
        }

        private void KinderDataButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(Views[0]);
        }

        private void KinderBijslagButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataPage.PeilDatum == null)
            {
                MessageBox.Show("Selecteer eerst een peildatum");
                return;
            }
            MainFrame.NavigationService.Navigate(Views[1]);
            ResultPage.UpdateResult(DataPage.Kinderen, DataPage.PeilDatum);
        }
    }
}
