using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_Manager
{
    class Log
    {
        public static void writeLog(int userId, string userName, bool success)
        {
            string msg = "";                                                                        // String to hold the final log message
            string filePath = "log.txt";                                                            // The path to the log
            string loginSuccess = $"{DateTime.Now.ToString()} - User Id:{userId.ToString()}, " +    // The successful login message
                $"User Name: {userName}, Message: Successful Login.";
            string loginFail = $"{DateTime.Now.ToString()} - User Id:{userId.ToString()}, " +       // The unsuccessful login message
                $"User Name: {userName}, Message: Successful Failed.";

            if (success) { msg = loginSuccess; }                                                    // Setting the appropriate message
            else {  msg = loginFail; }

            File.AppendAllText(filePath, msg);                                                      // Appending the message to the log file
        }
    }
}
