using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    public class Obligation
    {
        // PROPERTIES --------------------------------
        // NOTE TO SELF: the Id property is called something different for both inhereting classes
        public int Id { get; set; }
        public int userId { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}
