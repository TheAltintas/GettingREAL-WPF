using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal_Eydes.Models
{
    public class Item
    {
        // Static field to maintain a counter for assigning unique IDs to item objects
        private static int idCount = 0;

        // Properties for item attributes
        public int Id { get; } // Read-only property for the unique ID of the item
        public string ItemNumber { get; set; } // Property for the first name of the item
        public string ItemName { get; set; } // Property for the last name of the item
        public int NumOfItem { get; set; } // Property for the age of the item
        public string Storage { get; set; } // Property for the phone number of the item

        // Constructor for creating a new item object
        public Item()
        {
            Id = idCount++; // Assigning a unique ID to each new item and incrementing the counter
        }

        
    }
}
