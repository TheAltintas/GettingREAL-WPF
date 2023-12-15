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
using GettingReal_Eydes.ViewModels;

namespace GettingReal_Eydes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instance of the MainViewModel class for managing UI logic
        public MainViewModel mainViewModel;

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
            tbfn.IsReadOnly = true; // Set ItemNumber TextBox to read-only
            tbln.IsReadOnly = true; // Set ItemName TextBox to read-only
            tbphone.IsReadOnly = true; // Set Storage TextBox to read-only
            MessageBox.Show("The changes has been saved");
        }

        // Event handler for the edit button click
        private void editbt_Click(object sender, RoutedEventArgs e)
        {
            tbfn.IsReadOnly = false; // Enable editing ItemNumber TextBox
            tbln.IsReadOnly = false; // Enable editing ItemName TextBox
            tbphone.IsReadOnly = false; // Enable editing Storage TextBox
        }

        // Event handler for adding a new item
        private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.AddDefaultItem(); // Add a default item via MainViewModel
            listb.ScrollIntoView(mainViewModel.SelectedItem); // Scroll to the newly added person
            tbfn.IsReadOnly = false; // Enable editing ItemNumber TextBox
            tbphone.IsReadOnly = false; // Enable editing ItemName TextBox
            tbln.IsReadOnly = false; // Enable editing Storage TextBox
        }

        // Event handler for deleting an item
        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.DeleteSelectedItem(); // Delete the selected item via MainViewModel
        }

        private void backb_Click(object sender, RoutedEventArgs e)
        {
            FrontPage frontPage = new FrontPage();
            frontPage.Show();
            this.Close();
        }
    }
}
