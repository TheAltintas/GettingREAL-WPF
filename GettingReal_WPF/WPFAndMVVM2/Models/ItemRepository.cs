using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WPFAndMVVM2.Models
{
    public class ItemRepository
    {
        // File path for storing person data
        string fullpath = "Persons.csv";

        // Collection to hold Person objects
        private List<Item> items = new List<Item>();

        // Method to retrieve all persons
        public List<Item> GetItems()
        {
            return items;
        }

        // Constructor to initialize the repository by reading from the file
        public ItemRepository()
        {
            InitializeRepository();
        }

        // Method to read data from the file and populate the repository
        private void InitializeRepository()
        {
            try
            {
                // Open and read the file line by line
                using (StreamReader sr = new StreamReader(fullpath))
                {
                    String line = sr.ReadLine();

                    // Splitting each line by commas and adding data to the repository
                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        this.Add(parts[0], parts[1], int.Parse(parts[2]), parts[3]);

                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw; // Throw the exception up if encountered while reading
            }
        }

        // Method to save repository data back to the file
        public void SaveToFile()
        {
            try
            {
                // Open the file for writing
                using (StreamWriter sw = new StreamWriter(fullpath))
                {
                    // Write each person's data as a line in the file
                    foreach (var item in items)
                    {
                        string line = $"{item.ItemNumber},{item.ItemName},{item.NumOfItem},{item.Storage}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (IOException)
            {
                throw; // Throw the exception up if encountered while writing
            }
        }

        // Method to update persons' data from ViewModel objects
        public void UpdateItemsFromViewModels(ObservableCollection<ItemViewModel> itemsVM)
        {
            // Update each person's data from corresponding ViewModel
            for (int i = 0; i < items.Count && i < itemsVM.Count; i++)
            {
                items[i].ItemNumber = itemsVM[i].ItemNumber;
                items[i].ItemName = itemsVM[i].ItemName;
                items[i].NumOfItem = itemsVM[i].NumOfItem;
                items[i].Storage = itemsVM[i].Storage;
            }
        }

        // Method to add a new person
        public Item Add(string itemNumber, string itemName, int numOfItem, string storage)
        {
            // Check validity of input arguments and create a new person
            Item result = null;
            if (!string.IsNullOrEmpty(itemNumber) &&
                !string.IsNullOrEmpty(itemName) &&
                numOfItem >= 0 &&
                !string.IsNullOrEmpty(storage))
            {
                result = new Item()
                {
                    ItemNumber = itemNumber,
                    ItemName = itemName,
                    NumOfItem = numOfItem,
                    Storage = storage
                };
                items.Add(result); // Add the person to the repository
            }
            else
                throw (new ArgumentException("Not all arguments are valid")); // Throw exception for invalid arguments

            return result;
        }

        // Method to get a person by their ID
        public Item Get(int id)
        {
            // Search for a person with the given ID
            Item result = null;
            foreach (Item i in items)
            {
                if (i.Id == id)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        // Method to get all persons in the repository
        public List<Item> GetAll()
        {
            return items;
        }

        // Method to update a person's data by their ID
        public void Update(int id, string itemNumber, string itemName, int numOfItem, string storage)
        {
            // Find the person by ID and update their data if arguments are valid
            Item foundPerson = this.Get(id);

            if (foundPerson != null)
            {
                if (!string.IsNullOrEmpty(itemNumber) &&
                    !string.IsNullOrEmpty(itemName) &&
                    numOfItem >= 0 &&
                    !string.IsNullOrEmpty(storage))
                {
                    // Update the person's data if any change is detected
                    if (foundPerson.ItemNumber != itemNumber)
                        foundPerson.ItemNumber = itemNumber;
                    if (foundPerson.ItemName != itemName)
                        foundPerson.ItemName = itemName;
                    if (foundPerson.NumOfItem != numOfItem)
                        foundPerson.NumOfItem = numOfItem;
                    if (foundPerson.Storage != storage)
                        foundPerson.Storage = storage;
                }
                else
                    throw (new ArgumentException("Not all arguments for person are valid")); // Throw exception for invalid arguments
            }
            else
                throw (new ArgumentException("Person with id = " + id + " not found")); // Throw exception if person with ID not found
        }

        // Method to remove a person by their ID
        public void Remove(int id)
        {
            // Find and remove the person by ID
            Item foundItem = this.Get(id);

            if (foundItem != null)
                items.Remove(foundItem); // Remove the person from the repository
            else
                throw (new ArgumentException("Person with id = " + id + " not found")); // Throw exception if person with ID not found
        }
    }
}
