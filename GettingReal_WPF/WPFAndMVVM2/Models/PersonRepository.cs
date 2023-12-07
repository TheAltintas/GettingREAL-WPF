using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WPFAndMVVM2.Models
{
    public class PersonRepository
    {
        // File path for storing person data
        string fullpath = "Persons.csv";

        // Collection to hold Person objects
        private List<Person> persons = new List<Person>();

        // Method to retrieve all persons
        public List<Person> GetPersons()
        {
            return persons;
        }

        // Constructor to initialize the repository by reading from the file
        public PersonRepository()
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
                    foreach (var person in persons)
                    {
                        string csvLine = $"{person.FirstName},{person.LastName},{person.Age},{person.Phone}";
                        sw.WriteLine(csvLine);
                    }
                }
            }
            catch (IOException)
            {
                throw; // Throw the exception up if encountered while writing
            }
        }

        // Method to update persons' data from ViewModel objects
        public void UpdatePersonsFromViewModels(ObservableCollection<PersonViewModel> personsVM)
        {
            // Update each person's data from corresponding ViewModel
            for (int i = 0; i < persons.Count && i < personsVM.Count; i++)
            {
                persons[i].FirstName = personsVM[i].FirstName;
                persons[i].LastName = personsVM[i].LastName;
                persons[i].Age = personsVM[i].Age;
                persons[i].Phone = personsVM[i].Phone;
            }
        }

        // Method to add a new person
        public Person Add(string firstName, string lastName, int age, string phone)
        {
            // Check validity of input arguments and create a new person
            Person result = null;
            if (!string.IsNullOrEmpty(firstName) &&
                !string.IsNullOrEmpty(lastName) &&
                age >= 0 &&
                !string.IsNullOrEmpty(phone))
            {
                result = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Phone = phone
                };
                persons.Add(result); // Add the person to the repository
            }
            else
                throw (new ArgumentException("Not all arguments are valid")); // Throw exception for invalid arguments

            return result;
        }

        // Method to get a person by their ID
        public Person Get(int id)
        {
            // Search for a person with the given ID
            Person result = null;
            foreach (Person p in persons)
            {
                if (p.Id == id)
                {
                    result = p;
                    break;
                }
            }
            return result;
        }

        // Method to get all persons in the repository
        public List<Person> GetAll()
        {
            return persons;
        }

        // Method to update a person's data by their ID
        public void Update(int id, string firstName, string lastName, int age, string phone)
        {
            // Find the person by ID and update their data if arguments are valid
            Person foundPerson = this.Get(id);

            if (foundPerson != null)
            {
                if (!string.IsNullOrEmpty(firstName) &&
                    !string.IsNullOrEmpty(lastName) &&
                    age >= 0 &&
                    !string.IsNullOrEmpty(phone))
                {
                    // Update the person's data if any change is detected
                    if (foundPerson.FirstName != firstName)
                        foundPerson.FirstName = firstName;
                    if (foundPerson.LastName != lastName)
                        foundPerson.LastName = lastName;
                    if (foundPerson.Age != age)
                        foundPerson.Age = age;
                    if (foundPerson.Phone != phone)
                        foundPerson.Phone = phone;
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
            Person foundPerson = this.Get(id);

            if (foundPerson != null)
                persons.Remove(foundPerson); // Remove the person from the repository
            else
                throw (new ArgumentException("Person with id = " + id + " not found")); // Throw exception if person with ID not found
        }
    }
}
