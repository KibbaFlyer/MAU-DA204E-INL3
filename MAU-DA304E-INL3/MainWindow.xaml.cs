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
using MAU_DA304E_INL3.ViewModel;

namespace MAU_DA304E_INL3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /// Setting the DataContext, I have chosen a MVVM workflow since as I have understood it, it is very popular
            DataContext = new BmiCalculationViewModel();
            InitializeComponent();
        }

    }
}
