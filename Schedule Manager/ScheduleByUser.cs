using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    internal class ScheduleByUser
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string customerName { get; set; }
        public string type { get; set; }
    }
}
