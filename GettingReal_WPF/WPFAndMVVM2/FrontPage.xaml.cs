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
using System.Windows.Shapes;

namespace GettingReal_Eydes
{
    /// <summary>
    /// Interaction logic for FrontPage.xaml
    /// </summary>
    public partial class FrontPage : Window
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string enteredPassword = passbox.Password;

            if (enteredPassword == "6619")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.btnDeletePerson.Visibility = Visibility.Visible; 
                mainWindow.btnNewPerson.Visibility = Visibility.Visible;
                mainWindow.editbt.Visibility = Visibility.Visible;
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
        }

        private void prokatalog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.btnDeletePerson.Visibility = Visibility.Collapsed;
            mainWindow.btnNewPerson.Visibility = Visibility.Collapsed;
            mainWindow.editbt.Visibility = Visibility.Collapsed;
            mainWindow.Show();
            this.Close();

        }
    }
}
