using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPFAndMVVM2.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ItemRepository itemRepo = new ItemRepository();
        private ObservableCollection<ItemViewModel> itemsVM;
        private ItemViewModel selectedItem;

        // Property to hold a collection of PersonViewModels
        public ObservableCollection<ItemViewModel> ItemsVM
        {
            get { return itemsVM; }
            set
            {
                if (value != itemsVM)
                {
                    itemsVM = value;
                    OnPropertyChanged(nameof(ItemsVM));
                }
            }
        }

        // Constructor for MainViewModel
        public MainViewModel()
        {
            ItemsVM = new ObservableCollection<ItemViewModel>(); // Initialize PersonsVM collection

            UpdateItemsVM(); // Populate PersonsVM initially
            SaveChangesCommand = new RelayCommand(SaveChangesToFile, () => true); // Command for saving changes
        }

        // Command to save changes
        public ICommand SaveChangesCommand { get; private set; }

        // Method to save changes to file
        public void SaveChangesToFile()
        {
            try
            {
                itemRepo.UpdateItemsFromViewModels(ItemsVM); // Update Person objects from ViewModels

                itemRepo.SaveToFile(); // Save changes to file

                UpdateItemsVM(); // Update the ViewModel collection

                SelectedItem = null; // Clear selected person after saving changes
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An IO error occurred while saving changes: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving changes: {ex.Message}");
            }
        }

        // Property for the selected person in the UI
        public ItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        // Method to update PersonsVM collection from PersonRepository
        private void UpdateItemsVM()
        {
            ItemsVM.Clear(); // Clear existing elements
            foreach (Item item in itemRepo.GetItems())
            {
                ItemViewModel itemViewModel = new ItemViewModel(item);
                ItemsVM.Add(itemViewModel);
            }
            OnPropertyChanged(nameof(ItemsVM));
        }

        // INotifyPropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise PropertyChanged event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to add a default person to the collection
        public void AddDefaultItem()
        {
            Item item = itemRepo.Add("Specify item number", "Specify item", 0, "Specify storage");
            ItemViewModel itemViewModel = new ItemViewModel(item);
            ItemsVM.Add(itemViewModel);
            SelectedItem = itemViewModel;
        }

        // Method to delete the selected person from the collection
        public void DeleteSelectedItem()
        {
            selectedItem.DeleteItem(itemRepo); // Delete person from repository
            ItemsVM.Remove(SelectedItem); // Remove person from ViewModel collection
        }
    }
}
