using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Schedule_Manager
{
    public class DataBase
    {
        public static string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        public string Connect()
        {
            
            MySqlConnection conn = new MySqlConnection(constr);
            
            string q = "select * from address";
            MySqlCommand cmd = new MySqlCommand(q, conn);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            conn.Open();
            return adap.ToString();
        }
    }
}
