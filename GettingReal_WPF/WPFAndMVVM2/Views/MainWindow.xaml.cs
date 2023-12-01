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
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;


        }


        private void saveb_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.SaveChangesToFile();
            tbfn.IsReadOnly = true;
            tbln.IsReadOnly = true;
            tbphone.IsReadOnly = true;
        }

        private void editbt_Click(object sender, RoutedEventArgs e)
        {
            tbfn.IsReadOnly = false;
            tbln.IsReadOnly = false;
            tbphone.IsReadOnly = false;
        }
    }
}
