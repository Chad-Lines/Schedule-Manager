using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    public class Task : CalendarItem
    {
        // PROPERTIES --------------------------------

        // NOTE TO SELF: the Id property is called "taskId" in the Database
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }
}
