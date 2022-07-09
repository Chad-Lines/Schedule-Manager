using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    public class Appointment : CalendarItem
    {
        // PROPERTIES --------------------------------
        
        // NOTE TO SELF: the Id property is called "appointmentId" in the Database
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string type { get; set; }

        // METHODS --------------------------------
        public override string ToString()
        {
            // Overriding the default display to show useful information about a given Product
            return start + " -> [ " + start + "] to [" + end + "]: Type: " + type;
        }


    }
}
