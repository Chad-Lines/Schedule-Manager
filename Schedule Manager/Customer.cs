using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    internal class Customer
    {
        // PROPERTIES --------------------------------
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public bool active { get; set; } 
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }   
        public string lastUpdateBy { get; set; }

        // METHODS --------------------------------
        public override string ToString()
        {
            // Overriding the default display to show useful information about a given Product
            return $"{customerName}";
        }
    }
}
