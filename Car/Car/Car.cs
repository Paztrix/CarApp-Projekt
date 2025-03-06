public class Car
{
    //Private attributter for Car klassen
    private string brand;
    private string model;
    private int year;
    private char gear;
    private double odometer;
    private string fuelType;
    private bool isEngineOn;
    private double kmPerLiter;
    private double literPrice;

    //Get- og Set-metoder for attributterne
    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public char Gear
    {
        get { return gear; }
        set { gear = value; }
    }

    public double Odometer
    {
        get { return odometer; }
        set { odometer = value; }
    }

    public string FuelType
    {
        get { return fuelType; }
        set { fuelType = value; }
    }

    public bool IsEngineOn
    {
        get { return isEngineOn; }
        set { isEngineOn = value; }
    }

    public double KmPerLiter
    {
        get { return kmPerLiter; }
        set { kmPerLiter = value; }
    }

    //Konstruktør, der tager de nødvendige parametre
    public Car(string brand, string model, int year, char gear, double kmPerLiter, string fuelType, double odometer)
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
        if (fuelType.ToLower() == "benzin")
        {
            this.literPrice = 13.49;
        }
        else if (fuelType.ToLower() == "diesel")
        {
            this.literPrice = 12.29;
        }
        else
        {
            Console.WriteLine("Ukendt brændstoftype. Standard literpris er sat.");
            this.literPrice = 13.49;
        }
    }

    //Drive metode
    public void Drive(double distance)
    {
        if (isEngineOn)
        {
            odometer += distance;
            Console.WriteLine($"Du kørte {distance} km. Odometer: {odometer} km.");
        }
        else
        {
            Console.WriteLine("Motoren er slukket.");
        }
    }

    //CalculateTripPrice metode
    public void CalculateTripPrice(double distance, double userKmPerLiter)
    {
        if (userKmPerLiter == 0)
        {
            Console.WriteLine("Km per liter værdi kan ikke være 0, prøv igen!");
            return;
        }

        double fuelNeeded = distance / userKmPerLiter;
        double tripCost = fuelNeeded * literPrice;

        Console.WriteLine($"Brændstofudgifterne for {distance} km, er {tripCost:F2} kr.");
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
}