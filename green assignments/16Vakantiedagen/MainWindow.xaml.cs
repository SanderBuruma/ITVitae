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

namespace _16Vakantiedagen
{
    public partial class MainWindow : Window
    {
        private readonly Data DataPage = new Data();
        private readonly UserControl[] Views;
        public MainWindow()
        {
            InitializeComponent();

            Views = new UserControl[1]
            {
                DataPage,
            };

            MainFrame.NavigationService.Navigate(Views[0]);
        }
    }
}
