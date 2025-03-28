namespace DefaultNamespace;

public class Kontener_na_gaz : Kontener, IHazardNotifier
{
    private static int _numer = 1;
    public double Ciśnienie { get; private set; }
    
    public Kontener_na_gaz( double maxŁadowność, 
                        double wysokość, double wagaWłasna, double głębokość, double ciśnienie) : 
                        base("G", _numer++, maxŁadowność, wysokość, wagaWłasna, głębokość)
    {
        Ciśnienie = ciśnienie;
    }

    public override void Opróżnij()
    {
        MasaŁadunku = 0.05 * MasaŁadunku;
    }

    public void NotifyHazrd(string s)
    {
        Console.WriteLine($"Niebezpieczeństwo: {NumerSeryjny} {s}");
    }

    public override void Załaduj(double masa)
    {
        if (MasaŁadunku + masa > MaxŁadowność)
        {
            throw new OverflillException($"Próba przeładowania kontenera {NumerSeryjny}");
        }
        else
        {
            MasaŁadunku += masa;
        }
    }
    
}