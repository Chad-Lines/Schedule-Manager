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
        /* +-------------------------------------------------+
        * |                                                  |
        * | REQUIREMENT J: Record timestamps for user logins |
        * |                                                  |
        * +--------------------------------------------------+
        * By default the log is stored in \Schedule Manager\Schedule Manager\bin\Debug\log.txt
        */

        public static void writeLog(string userName, bool success)
        {
            string msg = "";                                                                        // String to hold the final log message
            string filePath = "log.txt";                                                            // The path to the log
            string loginSuccess = $"\n{DateTime.Now.ToString()} - " +                               // The successful login message
                $"User Name: {userName}, Message: Login Successful.";
            string loginFail = $"\n{DateTime.Now.ToString()} - " +                                  // The unsuccessful login message
                $"User Name: {userName}, Message: Login Failed.";

            if (success) { msg = loginSuccess; }                                                    // Setting the appropriate message
            else {  msg = loginFail; }

            File.AppendAllText(filePath, msg);                                                      // Appending the message to the log file
        }
    }
}
