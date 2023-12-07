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
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person person { get; set; } // Private member variable holding a reference to a Person object.

        // Constructor to initialize PersonViewModel with a Person object.
        public PersonViewModel(Person person)
        {
            this.person = person; // Initialize the person member variable with the given Person object.
            FirstName = person.FirstName; // Set FirstName to the value from the corresponding Person object.
            LastName = person.LastName; // Set LastName to the value from the corresponding Person object.
            Age = person.Age; // Set Age to the value from the corresponding Person object.
            Phone = person.Phone; // Set Phone to the value from the corresponding Person object.
        }

        // PropertyChanged event used to notify about property changes.
        public event PropertyChangedEventHandler PropertyChanged;

        // Property for FirstName with OnPropertyChanged method call.
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        // Property for LastName with OnPropertyChanged method call.
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        // Property for Age with OnPropertyChanged method call.
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        // Property for Phone with OnPropertyChanged method call.
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        // Method to raise the PropertyChanged event.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to delete a Person from the repository via PersonRepository.
        public void DeletePerson(PersonRepository personRepository)
        {
            personRepository.Remove(person.Id);
        }
    }
}
