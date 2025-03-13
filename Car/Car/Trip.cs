public class Trip
{
    private double distance;
    private DateTime tripDate;
    private DateTime startTime;
    private DateTime endTime;

    //get set for attributter
    public double Distance { get { return distance; } set { distance = value; } }

    public DateTime TripDate { get { return tripDate; } set { tripDate = value; } }

    public DateTime StartTime { get { return startTime; } set { startTime = value; } }

    public DateTime EndTime { get { return endTime; } set { endTime = value; } }

    //Konstruktør for Trip-klassen
    public Trip(double distance, DateTime tripDate, DateTime startTime, DateTime endTime)
    {
        this.distance = distance;
        this.tripDate = tripDate;
        this.startTime = startTime;
        this.endTime = endTime;
    }

    //Beregner tiden turen tager
    public TimeSpan CalculateDuration ()
    {
        return endTime - startTime;
    }

    //Beregner brændstof brugt for turen
    public double CalculateFuelUsed(double userKmPerLiter)
    {
        double fuelUsed = distance / userKmPerLiter;
        return fuelUsed;
        //Console.WriteLine($"Du har brugt {fuelUsed} på turen");
    }

    //Beregner prisen for turen
    public double CalculateTripPrice(double literPrice, double userKmPerLiter)
    {
        /*if (userKmPerLiter == 0)
        {
            Console.WriteLine("Km per liter værdi kan ikke være 0, prøv igen!");
            return;
        }

        double fuelNeeded = distance / userKmPerLiter;
        double tripCost = fuelNeeded * literPrice;

        Console.WriteLine($"Brændstofudgifterne for {distance} km, er {tripCost:F2} kr."); */

        double fuelUsed = distance / userKmPerLiter;
        return fuelUsed * literPrice;
    }

    //Udskriver turens oplysninger til console
    public void PrintTripDetails()
    {
        Console.WriteLine("Turen: ");
        Console.WriteLine($"Dato: {tripDate.ToShortDateString()}");
        Console.WriteLine($"Starttid: {startTime.ToShortTimeString()}");
        Console.WriteLine($"Sluttid: {endTime.ToShortTimeString()}");
        Console.WriteLine($"Distance: {distance} km");
        Console.WriteLine($"Varighed: {CalculateDuration()}");
    }
}