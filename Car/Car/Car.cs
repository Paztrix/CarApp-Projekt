public enum FuelType
{
    Benzin,
    Diesel,
    Electrisk,
    Hybrid
}
public class Car
{
    //Private attributter for Car klassen
    private string brand;
    private string model;
    private int year;
    private char gear;
    private double odometer;
    private FuelType fuelType;
    private bool isEngineOn;
    private double kmPerLiter;
    private double literPrice;

    //Liste over ture bilen har kørt
    public List<Trip> trips = new List<Trip>();
    //Liste til at lagre alle biler
    public static List<Car> allCars = new List<Car>();

    //Get- og Set-metoder for attributterne
    public string Brand { get { return brand; } set { brand = value; } }

    public string Model { get { return model; } set { model = value; } }

    public int Year { get { return year; } set { year = value; } }

    public char Gear { get { return gear; } set { gear = value; } }

    public double Odometer { get { return odometer; } set { odometer = value; } }

    public FuelType FuelType { get { return fuelType; } set { fuelType = value; } }

    public bool IsEngineOn { get { return isEngineOn; } set { isEngineOn = value; } }

    public double KmPerLiter { get { return kmPerLiter; } set { kmPerLiter = value; } }

    public double LiterPrice { get { return literPrice; } }

    //Konstruktør, der tager de nødvendige parametre
    public Car(string brand, string model, int year, char gear, double kmPerLiter, FuelType fuelType, double odometer)
    {
        this.brand = brand;
        this.model = model;
        this.year = year;
        this.gear = gear;
        this.odometer = odometer; //Initialisering af odometer med brugeres input
        this.fuelType = fuelType;
        this.isEngineOn = false; //Motoren er slukket ved oprettelse
        this.kmPerLiter = kmPerLiter;

        //Sæt literprisen efter brændstoftypen
        switch (fuelType)
        {
            case FuelType.Benzin:
                this.literPrice = 13.49;
                break;
            case FuelType.Diesel:
                this.literPrice = 12.29;
                break;
            case FuelType.Electrisk:
                this.literPrice = 9.95;
                break;
            case FuelType.Hybrid:
                this.literPrice = 10.99;
                break;
            default:
                Console.WriteLine("Unknown fuel type. Default liter price is set.");
                this.literPrice = 13.49;
                break;
        }

        allCars.Add(this);
    }

    //Drive metode
    public void Drive(Trip newTrip)
    {
        if (isEngineOn)
        {
            odometer += newTrip.Distance;
            trips.Add(newTrip);
            Console.WriteLine($"Turen på {newTrip.Distance} km er tilføjet til listen. Odometer er nu: {odometer} km.");
        }
        else
        {
            Console.WriteLine("Motoren er slukket.");
        }
    }

    //Udskriver alle ture for bilen og kalder metoden PrintTripDetails() for hver tur
    public void PrintAllTrips()
    {
        if (trips.Count == 0)
        {
            Console.WriteLine("Der er ikke registreret nogle ture!");
            return;
        }

        Console.WriteLine("Alle ture for din nuværende bil");
        foreach (Trip trip in trips)
        {
            trip.PrintTripDetails();
            Console.WriteLine();
        }
    }

    //PrintCarDetails metode
    public void PrintCarDetails()
    {
        Console.WriteLine("Bilmærke: " + brand);
        Console.WriteLine("Bilmodel: " + model);
        Console.WriteLine("Årgang: " + year);
        Console.WriteLine("Gear: " + gear);
        Console.WriteLine("Brændstoftype: " + fuelType);
        Console.WriteLine("Km per liter: " + kmPerLiter + " km/l");
        Console.WriteLine("Kilometerstand: " + odometer + " km");
    }

    //Metode til at starte bilen
    public void StartEngine()
    {
        isEngineOn = true;
        Console.WriteLine("Motoren er tændt");
    }

    //Metode til at stoppe bilen
    public void StopEngine()
    {
        isEngineOn = false;
        Console.WriteLine("Motoren er slukket");
    }

    //Metode til at printe alle biler indtastet af brugeren
    public static void PrintAllTeamCars()
    {
        if (allCars.Count == 0)
        {
            Console.WriteLine("Du mangler at registrere nogle biler!");
        } 
        else
        {
            foreach (var car in allCars)
            {
                car.PrintCarDetails();
                Console.WriteLine();
            }
        }
    }
}