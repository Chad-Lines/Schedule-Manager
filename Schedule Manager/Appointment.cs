using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    internal class Appointment
    {
        // PROPERTIES --------------------------------
        public int  appointmentId { get; set; }
        public int customerId { get; set; }
        public int userId { get; set; }
        public string type { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        // METHODS --------------------------------
        public override string ToString()
        {
            // Overriding the default display to show useful information about a given Product
            return start.Date.ToString() + " -> [ " + start.TimeOfDay.ToString() + "] to [" + end.TimeOfDay.ToString() + "]: Type: " + type;
        }


    }
}
