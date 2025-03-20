using Microsoft.VisualBasic.FileIO;
using CarApp;

namespace CarApp
{
    [TestClass]
    public class Drive_Tests
    {
        private Car _car;
        private Trip _trip;

        // Initialize a new car and trip before each test
        [TestInitialize]
        public void Setup()
        {
            _car = new Car(
                "Toyota",          // brand
                "Corolla",         // model
                 2025,             // year
                'A',               // gear (for automatic)
                15.0,              // kmPerLiter (fuel efficiency)
                FuelType.Benzin,   // fuelType
                100                // odometer (starting km)
            );

            _trip = new Trip(
                100,                        // distance (100 km)
                DateTime.Now.Date,          // tripDate (current date)
                DateTime.Now,               // startTime (current time)
                DateTime.Now.AddHours(1)    // endTime (1 hour after the start time)
            );
        }

        //Test scenarie hvor motoren er tændt
        [TestMethod]
        public void Drive_EngineIsOn_UpdatesOdometerAndCalculatesFuelUsed()
        {
            //Arrange: Sæt motoren som tændt
            _car.IsEngineOn = true;

            //Act: kald Drive metoden
            _car.Drive(_trip);

            //Assert: Tjek om odometeret bliver opdateres og om brændstofforbruget bliver udregnet rigtigt
            Assert.AreEqual(100 + _trip.Distance, _car.Odometer); //Odometer skulle være 200 efter en tur
            Assert.AreEqual(_trip.Distance / _car.KmPerLiter, _trip.FuelUsed); //FuelUsed burde være distancen divideret med fuel efficiency
            Assert.AreEqual(_trip.FuelUsed * _car.LiterPrice, _trip.TripPrice); //TripPrice burde være brændstofforbruget gange pris per kilometer
        }

        //Test scenarie hvor motoren er slukket
        [TestMethod]
        public void Drive_EngineIsOff_DoesNotUpdateOdometer()
        {
            //Arrange: Sæt motoren som slukket
            _car.IsEngineOn = false;

            double initialOdometer = _car.Odometer;

            //Act: kalder Drive metoden
            _car.Drive(_trip);

            //Assert: Tjek at odometeret ikke bliver opdateret og der bliver sendt den rigitge fejl-besked
            Assert.AreEqual(initialOdometer, _car.Odometer); //Odometeret skulle gerne være uændret, for at tjekke fejl-besked skal der laves en mock consol for at se det
        }

        [TestMethod]
        public void Drive_EngineIsOff_DisplayErrorMessage()
        {
            //Arrange: Sæt motoren som slukket
            _car.IsEngineOn = false;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act: kalder Drive metoden
            _car.Drive(_trip);

            //Assert: verificer at fejl-beskeden blev sendt
            string output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("Motoren er slukket."));
        }
    }
}
