using System; // Import the System namespace, providing access to fundamental system classes and functionality.
using System.Collections.Generic; // Import classes for working with lists and collections.
using System.ComponentModel; // Import classes for component-based development, including the INotifyPropertyChanged interface.
using System.Linq; // Import functionality for working with LINQ (Language Integrated Query).
using System.Text; // Import functionality for working with text.
using System.Threading.Tasks; // Import classes for working with asynchronous programming and tasks.

using WPFAndMVVM2.Models; // Import models from the WPFAndMVVM2 namespace.

namespace WPFAndMVVM2
{
    // PersonViewModel class implementing INotifyPropertyChanged.
    public class ItemViewModel : INotifyPropertyChanged
    {
        private Item person { get; set; } // Private member variable holding a reference to a Person object.

        // Constructor to initialize PersonViewModel with a Person object.
        public ItemViewModel(Item person)
        {
            this.person = person; // Initialize the person member variable with the given Person object.
            ItemNumber = person.ItemNumber; // Set FirstName to the value from the corresponding Person object.
            ItemName = person.ItemName; // Set LastName to the value from the corresponding Person object.
            NumOfItem = person.NumOfItem; // Set Age to the value from the corresponding Person object.
            Storage = person.Storage; // Set Phone to the value from the corresponding Person object.
        }

        // PropertyChanged event used to notify about property changes.
        public event PropertyChangedEventHandler PropertyChanged;

        // Property for FirstName with OnPropertyChanged method call.
        private string _firstName;
        public string ItemNumber
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(ItemNumber));
                }
            }
        }

        // Property for LastName with OnPropertyChanged method call.
        private string _lastName;
        public string ItemName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(ItemName));
                }
            }
        }

        // Property for Age with OnPropertyChanged method call.
        private int _age;
        public int NumOfItem
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(NumOfItem));
                }
            }
        }

        // Property for Phone with OnPropertyChanged method call.
        private string _phone;
        public string Storage
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Storage));
                }
            }
        }

        // Method to raise the PropertyChanged event.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to delete a Person from the repository via PersonRepository.
        public void DeleteItem(ItemRepository personRepository)
        {
            personRepository.Remove(person.Id);
        }
    }
}
