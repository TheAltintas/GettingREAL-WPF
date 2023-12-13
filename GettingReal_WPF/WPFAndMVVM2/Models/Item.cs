using System;
using System.Collections.Generic;
using System.Text;

namespace WPFAndMVVM2.Models
{
    public class Item
    {
        // Static field to maintain a counter for assigning unique IDs to Person objects
        private static int idCount = 0;

        // Properties for Person attributes
        public int Id { get; } // Read-only property for the unique ID of the Person
        public string ItemNumber { get; set; } // Property for the first name of the Person
        public string ItemName { get; set; } // Property for the last name of the Person
        public int NumOfItem { get; set; } // Property for the age of the Person
        public string Storage { get; set; } // Property for the phone number of the Person

        // Constructor for creating a new Person object
        public Item()
        {
            Id = idCount++; // Assigning a unique ID to each new Person and incrementing the counter
        }

        
    }
}
