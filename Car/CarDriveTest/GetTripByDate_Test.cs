using Microsoft.VisualBasic.FileIO;
using CarApp;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace CarApp
{
    [TestClass]
    public class GetTripByDate_Tests
    {
        private Car _car;

        // Initialize a new car before each test
        [TestInitialize]
        public void Setup()
        {
            _car = new Car(
                "Toyota",          // brand
                "Corolla",         // model
                2025,              // year
                'A',               // gear (for automatic)
                15.0,              // kmPerLiter (fuel efficiency)
                FuelType.Benzin,   // fuelType
                100               // odometer (starting km)
            );
        }

        [TestMethod]
        public void GetTripByDate_DateMatchesMultipleTrips_PrintsCorrectTrips()
        {
            //Arrange: sæt motoren som tændt
            _car.IsEngineOn = true;

            //Arrange: tilføjer flere trips med samme dato
            DateTime tripDate = DateTime.Now.Date;
            _car.Drive(new Trip(50, tripDate, DateTime.Now, DateTime.Now.AddHours(1)));
            _car.Drive(new Trip(100, tripDate, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2)));
            _car.Drive(new Trip(75, tripDate, DateTime.Now.AddHours(2), DateTime.Now.AddHours(3)));

            //Act: fanger console output når den kalder GetTripByDate metoden
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); //sender console output til StringWriter

                _car.GetTripByDate(tripDate); //kalder metoden

                //Assert: tjekker at alle trips blev printet rigtigt
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("--- Information om turen/turene ---")); // Ensure it contains the trip details
                Assert.IsTrue(output.Contains("Distance: 50")); //tjekker distance på første trip
                Assert.IsTrue(output.Contains("Distance: 100")); //tjekker distance på andet trip
                Assert.IsTrue(output.Contains("Distance: 75")); //tjekker distance på tredje trip
            }
        }

        [TestMethod]
        public void GetTripByDate_DateMatchesNoTrips_PrintsNoTripsMessage()
        {
            //Arrange: ingen trips blev tilføjet til denne dato
            DateTime tripDate = DateTime.Now.Date.AddDays(1); // Use a future date that has no trips

            //Act: fanger console output når den kalder GetTripByDate metoden
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); //sender console output til StringWriter

                _car.GetTripByDate(tripDate); //kalder metoden

                //Assert: tjekker at ingen trips beskeder blev printet til console
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("Der blev ikke fundet nogle ture på den angivne dato.")); //tjekker for ingen trips besked
            }
        }
    }
}