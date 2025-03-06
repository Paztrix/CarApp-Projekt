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

            Car car = null;

            while (!exit)
            {
                Console.WriteLine("Vælg en funktion!: ");
                Console.WriteLine("1. Indlæs bilens oplysninger");
                Console.WriteLine("2. Start motoren");
                Console.WriteLine("3. Kør en tur");
                Console.WriteLine("4. Beregn prisen for en køretur");
                Console.WriteLine("5. Udskriv bilens oplysninger");
                Console.WriteLine("6. Tjek om kilometerstanden er palindrom");
                Console.WriteLine("7. Afslut");
                Console.Write("Indtast valg: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        car = ReadCarDetails();
                        break;
                    case "2":
                        if (car != null)
                        {
                            car.StartEngine();
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        break;
                    case "3":
                        if (car != null)
                        {
                            Console.Write("Turens distance: ");
                            userDistance = Convert.ToDouble(Console.ReadLine());
                            car.Drive(userDistance);
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        break;
                    case "4":
                        if (car != null)
                        {
                            Console.Write("Turens distance: ");
                            userDistance = Convert.ToDouble(Console.ReadLine());
                            car.CalculateTripPrice(userDistance, car.KmPerLiter);
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        break;
                    case "5":
                        if (car != null)
                        {
                            car.PrintCarDetails();
                        }
                        else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        break;
                    case "6":
                        if (car != null)
                        {
                            IsPalindrome(car.Odometer);
                        } else
                        {
                            Console.WriteLine("Du skal indlæse bilens oplysninger først!");
                        }
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen!");
                        break;
                }
            }
        }

        //Tjekker om bilens kilometerstand/odometer er et palindrom
        static void IsPalindrome(double odometer)
        {
            string odometerStr = odometer.ToString();
            string reversed = new string(odometerStr.Reverse().ToArray());

            if (odometerStr == reversed)
            {
                Console.WriteLine($"Kilometerstanden {odometer}, er et palindrom");
            } else
            {
                Console.WriteLine($"Kilometerstanden {odometer}, er ikke et palindrom");
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