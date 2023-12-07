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
        private PersonRepository personRepo = new PersonRepository();
        private ObservableCollection<PersonViewModel> personsVM;
        private PersonViewModel selectedPerson;

        // Property to hold a collection of PersonViewModels
        public ObservableCollection<PersonViewModel> PersonsVM
        {
            get { return personsVM; }
            set
            {
                if (value != personsVM)
                {
                    personsVM = value;
                    OnPropertyChanged(nameof(PersonsVM));
                }
            }
        }

        // Constructor for MainViewModel
        public MainViewModel()
        {
            PersonsVM = new ObservableCollection<PersonViewModel>(); // Initialize PersonsVM collection

            UpdatePersonsVM(); // Populate PersonsVM initially
            SaveChangesCommand = new RelayCommand(SaveChangesToFile, () => true); // Command for saving changes
        }

        // Command to save changes
        public ICommand SaveChangesCommand { get; private set; }

        // Method to save changes to file
        public void SaveChangesToFile()
        {
            try
            {
                personRepo.UpdatePersonsFromViewModels(PersonsVM); // Update Person objects from ViewModels

                personRepo.SaveToFile(); // Save changes to file

                UpdatePersonsVM(); // Update the ViewModel collection

                SelectedPerson = null; // Clear selected person after saving changes
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
        public PersonViewModel SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (value != selectedPerson)
                {
                    selectedPerson = value;
                    OnPropertyChanged(nameof(SelectedPerson));
                }
            }
        }

        // Method to update PersonsVM collection from PersonRepository
        private void UpdatePersonsVM()
        {
            PersonsVM.Clear(); // Clear existing elements
            foreach (Person person in personRepo.GetPersons())
            {
                PersonViewModel personViewModel = new PersonViewModel(person);
                PersonsVM.Add(personViewModel);
            }
            OnPropertyChanged(nameof(PersonsVM));
        }

        // INotifyPropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise PropertyChanged event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to add a default person to the collection
        public void AddDefaultPerson()
        {
            Person person = personRepo.Add("Specify item number", "Specify item", 0, "Specify storage");
            PersonViewModel personViewModel = new PersonViewModel(person);
            PersonsVM.Add(personViewModel);
            SelectedPerson = personViewModel;
        }

        // Method to delete the selected person from the collection
        public void DeleteSelectedPerson()
        {
            selectedPerson.DeletePerson(personRepo); // Delete person from repository
            PersonsVM.Remove(SelectedPerson); // Remove person from ViewModel collection
        }
    }
}
