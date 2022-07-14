using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule_Manager;

namespace ScheduleManagerTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [Timeout(2000)] // Setting the timeout to 2000 milliseconds
        public void Check_Appointment_Start_Date_Must_Be_Before_EndDate()
        {
            // ARRANGE
            // Setting up the parameters to use for the test
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(1);

            Appointment appointment = new Appointment();
            appointment.customerId = 23;
            appointment.type = "Presentation";

            // ACT
            // Saving the start and end dates to he appointment
            appointment.start = startDate.ToString();
            appointment.end = endDate.ToString();

            // ASSERT
            // Check that the start date comes before the end date
            Assert.IsTrue(DateTime.Parse(appointment.start) < DateTime.Parse(appointment.end));            

        }
    }
}