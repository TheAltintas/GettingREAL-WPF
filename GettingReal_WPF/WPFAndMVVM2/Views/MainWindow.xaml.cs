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
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instance of the MainViewModel class for managing UI logic
        private MainViewModel mainViewModel;

        // Constructor for MainWindow
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel(); // Initializing the MainViewModel
            DataContext = mainViewModel; // Setting DataContext to bind UI elements to MainViewModel
        }

        // Event handler for the save button click
        private void saveb_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.SaveChangesToFile(); // Trigger MainViewModel to save changes to file
            tbfn.IsReadOnly = true; // Set FirstName TextBox to read-only
            tbln.IsReadOnly = true; // Set LastName TextBox to read-only
            tbphone.IsReadOnly = true; // Set Phone TextBox to read-only
        }

        // Event handler for the edit button click
        private void editbt_Click(object sender, RoutedEventArgs e)
        {
            tbfn.IsReadOnly = false; // Enable editing FirstName TextBox
            tbln.IsReadOnly = false; // Enable editing LastName TextBox
            tbphone.IsReadOnly = false; // Enable editing Phone TextBox
        }

        // Event handler for adding a new person
        private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.AddDefaultPerson(); // Add a default person via MainViewModel
            listb.ScrollIntoView(mainViewModel.SelectedPerson); // Scroll to the newly added person
            tbfn.IsReadOnly = false; // Enable editing FirstName TextBox
            tbphone.IsReadOnly = false; // Enable editing Phone TextBox
            tbln.IsReadOnly = false; // Enable editing LastName TextBox
        }

        // Event handler for deleting a person
        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.DeleteSelectedPerson(); // Delete the selected person via MainViewModel
        }
    }
}
