using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data;

namespace Schedule_Manager
{
    internal class DataBase
    {
        string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
    }
}
