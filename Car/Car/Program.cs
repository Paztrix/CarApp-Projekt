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

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Vælg en funktion!: ");
                Console.WriteLine("1. Indlæs bilens oplysninger");
                Console.WriteLine("2. Start motoren");
                Console.WriteLine("3. Kør en tur");
                Console.WriteLine("4. Beregn prisen for en køretur");
                Console.WriteLine("5. Udskriv bilens oplysninger");
                Console.WriteLine("6. Tjek om kilometerstanden er palindrom");
                Console.WriteLine("7. Print alle biler");
                Console.WriteLine("8. Afslut");
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
                            currentCar.Drive(userDistance);
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
                            currentCar.CalculateTripPrice(userDistance, currentCar.KmPerLiter);
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

            Console.Write("Indtast brændstoftype (Benzin/Diesel): ");
            string userFuelType = Console.ReadLine();

            Console.Write("Indtast km per liter: ");
            double userKmPerLiter = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast kilometerstand: ");
            double userOdometer = Convert.ToDouble(Console.ReadLine());

            Car car = new Car(userBrand, userModel, userYear, userGear, userKmPerLiter, userFuelType, userOdometer);
            return car;
        }
    }
}