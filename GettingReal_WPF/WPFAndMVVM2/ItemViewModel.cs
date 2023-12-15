using System; // Import the System namespace, providing access to fundamental system classes and functionality.
using System.Collections.Generic; // Import classes for working with lists and collections.
using System.ComponentModel; // Import classes for component-based development, including the INotifyPropertyChanged interface.
using System.Linq; // Import functionality for working with LINQ (Language Integrated Query).
using System.Text; // Import functionality for working with text.
using System.Threading.Tasks; // Import classes for working with asynchronous programming and tasks.

using GettingReal_Eydes.Models; // Import models from the WPFAndMVVM2 namespace.

namespace GettingReal_Eydes
{
    // PersonViewModel class implementing INotifyPropertyChanged.
    public class ItemViewModel : INotifyPropertyChanged
    {
        private Item item { get; set; } // Private member variable holding a reference to a Person object.

        // Constructor to initialize PersonViewModel with a Person object.
        public ItemViewModel(Item item)
        {
            this.item = item; // Initialize the person member variable with the given Person object.
            ItemNumber = item.ItemNumber; // Set FirstName to the value from the corresponding Person object.
            ItemName = item.ItemName; // Set LastName to the value from the corresponding Person object.
            NumOfItem = item.NumOfItem; // Set Age to the value from the corresponding Person object.
            Storage = item.Storage; // Set Phone to the value from the corresponding Person object.
        }

        // PropertyChanged event used to notify about property changes.
        public event PropertyChangedEventHandler PropertyChanged;

        // Property for ItemNumber with OnPropertyChanged method call.
        private string _itemNumber;
        public string ItemNumber
        {
            get { return _itemNumber; }
            set
            {
                if (_itemNumber != value)
                {
                    _itemNumber = value;
                    OnPropertyChanged(nameof(ItemNumber));
                }
            }
        }

        // Property for ItemName with OnPropertyChanged method call.
        private string _itemName;
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    OnPropertyChanged(nameof(ItemName));
                }
            }
        }

        // Property for NumOfItem with OnPropertyChanged method call.
        private int _numOfItem;
        public int NumOfItem
        {
            get { return _numOfItem; }
            set
            {
                if (_numOfItem != value)
                {
                    _numOfItem = value;
                    OnPropertyChanged(nameof(NumOfItem));
                }
            }
        }

        // Property for Storage with OnPropertyChanged method call.
        private string _storage;
        public string Storage
        {
            get { return _storage; }
            set
            {
                if (_storage != value)
                {
                    _storage = value;
                    OnPropertyChanged(nameof(Storage));
                }
            }
        }

        // Method to raise the PropertyChanged event.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to delete a Item from the repository via PersonRepository.
        public void DeleteItem(ItemRepository itemRepository)
        {
            itemRepository.Remove(item.Id);
        }
    }
}
