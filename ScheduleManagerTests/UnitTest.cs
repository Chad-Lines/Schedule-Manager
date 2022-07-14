using System.ComponentModel;
using Schedule_Manager;
using MySql.Data.MySqlClient;

namespace ScheduleManagerTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [Timeout(2000)] // Setting the timeout to 2000 milliseconds
        public void Check_Appointment()
        {
            // Setting the variables for the test
            DateTime rawStart = DateTime.Now;
            DateTime rawEnd = DateTime.Now.AddDays(1);

            // Creating the appointment
            Appointment testAppointment = new Appointment();
            testAppointment.customerId = 1;
            testAppointment.type = "Presentation";
            testAppointment.start = rawStart.ToString();
            testAppointment.end = rawEnd.ToString();

            // Make sure all the data is correct            
            Assert.IsTrue(testAppointment.customerId == 1);             // Check the Customer Id
            Assert.IsTrue(testAppointment.type == "Presentation");      // Check the type
            Assert.IsTrue(testAppointment.start == rawStart.ToString());// Check the start date
            Assert.IsTrue(testAppointment.end == rawEnd.ToString());    // Check the end date
            Assert.IsTrue(DateTime.Parse(testAppointment.start) < DateTime.Parse(testAppointment.end)); 
        }
    }
}