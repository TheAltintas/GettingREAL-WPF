using System;
using System.Collections.Generic;
using System.Text;

namespace WPFAndMVVM2.Models
{
    public class Person
    {
        // Static field to maintain a counter for assigning unique IDs to Person objects
        private static int idCount = 0;

        // Properties for Person attributes
        public int Id { get; } // Read-only property for the unique ID of the Person
        public string FirstName { get; set; } // Property for the first name of the Person
        public string LastName { get; set; } // Property for the last name of the Person
        public int Age { get; set; } // Property for the age of the Person
        public string Phone { get; set; } // Property for the phone number of the Person

        // Computed property for the full name of the Person
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        // Constructor for creating a new Person object
        public Person()
        {
            Id = idCount++; // Assigning a unique ID to each new Person and incrementing the counter
        }

        // Override of the ToString() method to represent Person object information as a string
        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName}: {Age} years; T: {Phone}";
        }
    }
}
