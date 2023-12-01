using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPFAndMVVM2.Models;
using System.Diagnostics;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository personRepo = new PersonRepository();
        private List<PersonViewModel> personsVM;
        private PersonViewModel selectedPerson;

        public List<PersonViewModel> PersonsVM
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

        public MainViewModel()
        {
            PersonsVM = new List<PersonViewModel>(); // Tilføj denne linje for at initialisere PersonsVM

            UpdatePersonsVM();
            SaveChangesCommand = new RelayCommand(SaveChangesToFile, () => true);
        }

        public ICommand SaveChangesCommand { get; private set; }

        public void SaveChangesToFile()
        {
            try
            {
                // Opdater persons-listen i PersonRepository med oplysningerne fra PersonsVM
                personRepo.UpdatePersonsFromViewModels(PersonsVM);

                // Gem ændringer til Persons.csv
                personRepo.SaveToFile();

                // Opdater PersonsVM efter at have gemt ændringerne
                UpdatePersonsVM();

                // Nulstil SelectedPerson
                SelectedPerson = null;
            }
            catch (IOException ex)
            {
                // Håndter IO-fejl, hvis nødvendigt
                MessageBox.Show($"An IO error occurred while saving changes: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Udskriv eventuelle andre undtagelser
                MessageBox.Show($"An error occurred while saving changes: {ex.Message}");
            }
        }

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

       private void UpdatePersonsVM()
        {
            PersonsVM.Clear(); // Ryd eksisterende elementer
            foreach (Person person in personRepo.GetPersons())
            {
                PersonViewModel personViewModel = new PersonViewModel(person);
                PersonsVM.Add(personViewModel);
            }
            OnPropertyChanged(nameof(PersonsVM));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
