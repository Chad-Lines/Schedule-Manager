using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    public class Appointment
    {
        // PROPERTIES --------------------------------
        public int  appointmentId { get; set; }
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int userId { get; set; }
        public string type { get; set; }
        public string start { get; set; }
        public string end { get; set; }

        // METHODS --------------------------------
        public override string ToString()
        {
            // Overriding the default display to show useful information about a given Product
            return start + " -> [ " + start + "] to [" + end + "]: Type: " + type;
        }


    }
}
