using System.Globalization;

namespace CarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userBrand, userModel, userFueltype;
            double userKmPerLiter, userDistance = 0.0, userOdometer;
            int userYear;
            char userGear;
            bool exit = false;
            Car currentCar = null;

            List<Trip> trips = new List<Trip>()
            {
                new Trip ( 50, DateTime.Now.Date, DateTime.Now, DateTime.Now.AddHours(1) ),
                new Trip ( 30, DateTime.Now.Date, DateTime.Now, DateTime.Now.AddMinutes(30) ),
                new Trip ( 100, DateTime.Now.Date, DateTime.Now, DateTime.Now.AddHours(2) )
            };

            Car myCar = new Car("Toyota", "Corolla", 2025, 'A', 15.0, FuelType.Benzin, 10000);
            myCar.StartEngine();

            foreach (var trip in trips)
            {
                myCar.Drive(trip);
            }
            // Print car details
            myCar.PrintCarDetails();  // Display car info

            // Print all trips for the car
            myCar.PrintAllTrips();  // Display all trips added to the car

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("--- Car System Menu ---");
                Console.WriteLine("1. Indlæs bilens oplysninger");
                Console.WriteLine("2. Start motoren");
                Console.WriteLine("3. Kør en tur");
                Console.WriteLine("4. Beregn prisen for en køretur");
                Console.WriteLine("5. Udskriv bilens oplysninger");
                Console.WriteLine("6. Tjek om kilometerstanden er palindrom");
                Console.WriteLine("7. Print alle biler");
                Console.WriteLine("8. Print alle ture");
                Console.WriteLine("9. Print ture efter dato");
                Console.WriteLine("10. Afslut");
                Console.Write("Indtast valg: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        currentCar = ReadCarDetails();
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        if (currentCar != null)
                        {
                            currentCar.StartEngine();
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        if (currentCar != null)
                        {
                            Console.Write("Turens distance: ");
                            userDistance = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Indtast turens dato (dd-mm-yyyy): ");
                            DateTime tripDate;
                            while (!DateTime.TryParseExact(Console.ReadLine(), "dd-mm-yyyy", null, System.Globalization.DateTimeStyles.None, out tripDate))
                            {
                                Console.WriteLine("Ugyldig dato!");
                                Console.WriteLine("Indtast turen dato (dd-mm-yyyy): ");
                            }

                            Console.Write("Indtast turens starttidspunkt (HH:mm): ");
                            DateTime startTime;
                            while (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out startTime))
                            {
                                Console.WriteLine("Ugyldigt starttidspunkt!");
                                Console.WriteLine("Indtast starttidspunkt (HH:mm)");
                            }

                            DateTime endTime = startTime.AddHours(1);

                            Trip newTrip = new Trip(userDistance, tripDate, startTime, endTime);

                            currentCar.Drive(newTrip);
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        if (currentCar != null)
                        {
                            Console.Write("Turens distance: ");
                            userDistance = Convert.ToDouble(Console.ReadLine());

                            DateTime currentTime = DateTime.Now;
                            Trip newTrip = new Trip(userDistance, currentTime.Date, currentTime, currentTime.AddHours(1));

                            double tripPrice = newTrip.CalculateTripPrice(currentCar.LiterPrice, currentCar.KmPerLiter);
                            Console.WriteLine($"Prisen for turen er: {tripPrice:F2} kr.");
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        if (currentCar != null)
                        {
                            currentCar.PrintCarDetails();
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        if (currentCar != null)
                        {
                            IsPalindrome(currentCar.Odometer);
                        } else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        Car.PrintAllTeamCars();
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.Clear();
                        if (currentCar != null)
                        {
                            currentCar.PrintAllTrips();
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "9":
                        Console.Clear();
                        if (currentCar != null)
                        {
                            Console.Write("Indtast den dato du gerne vil finde ture fra (dd-mm-yyyy): ");
                            DateTime searchDate;
                            while (!DateTime.TryParseExact(Console.ReadLine(), "dd-mm-yyyy", null, DateTimeStyles.None, out searchDate))
                            {
                                Console.WriteLine("Ugyldig dato!");
                                Console.Write("Indtast den dato du gerne vil finde ture fra (dd-mm-yyyy): ");
                            }

                            currentCar.GetTripByDate(searchDate);
                        } else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                    case "10":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen!");
                        Console.WriteLine("Tryk en vilkårlig tast for at vende tilbage til menuen...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //Tjekker om bilens kilometerstand/odometer er et palindrom
        static void IsPalindrome(double odometer)
        {
            string odometerStr = odometer.ToString();
            string odometerReversed = new string(odometerStr.Reverse().ToArray());

            if (odometerStr == odometerReversed)
            {
                Console.WriteLine($"Kilometerstanden {odometer}, er et palindrom");
                Console.WriteLine($"Odometer: {odometerStr}");
                Console.WriteLine($"Odometer omvendt: {odometerReversed}");
            } else
            {
                Console.WriteLine($"Kilometerstanden {odometer}, er ikke et palindrom");
                Console.WriteLine($"Odometer: {odometerStr}");
                Console.WriteLine($"Odometer omvendt: {odometerReversed}");
            }
        }

        //Indlæser bilens brugerindtastede oplysninger
        static Car ReadCarDetails()
        {
            Console.Write("Indtast bilmærke: ");
            string userBrand = Console.ReadLine();

            Console.Write("Indtast bilmodel: ");
            string userModel = Console.ReadLine();

            Console.Write("Indtast årgang: ");
            int userYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Indtast geartype (A for automatisk, M for manuel): ");
            char userGear = Console.ReadLine()[0];

            Console.Write("Indtast brændstoftype (Benzin/Diesel/Electrisk/Hybrid): ");
            string userFuelType = Console.ReadLine().ToLower();

            //Switch-case til at sammenligne input med enum FuelType og finde brændstofpris
            FuelType fuelType;
            switch (userFuelType)
            {
                case "benzin":
                    fuelType = FuelType.Benzin;
                    break;
                case "diesel":
                    fuelType = FuelType.Diesel;
                    break;
                case "electrisk":
                    fuelType = FuelType.Electrisk;
                    break;
                case "hybrid":
                    fuelType = FuelType.Hybrid;
                    break;
                default:
                    Console.WriteLine("Ugyldig brændstoftype, standarden 'Benzin' bliver brugt.");
                    fuelType = FuelType.Benzin; // Standard brænstoftype
                    break;
            }

            Console.Write("Indtast km per liter: ");
            double userKmPerLiter = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast kilometerstand: ");
            double userOdometer = Convert.ToDouble(Console.ReadLine());

            Car car = new Car(userBrand, userModel, userYear, userGear, userKmPerLiter, fuelType, userOdometer);
            return car;
        }
    }
}