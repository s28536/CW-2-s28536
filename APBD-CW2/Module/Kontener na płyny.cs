namespace DefaultNamespace;

public class Kontener_na_płyny : Kontener, IHazardNotifier
{
    private static int _numer = 1;
    public bool Niebezpieczny { get; set; }
    
    public Kontener_na_płyny(string typ, int numer, double maxŁadowność, 
                            double wysokość, double wagaWłasna, double głębokość, bool niebezpieczny) : 
                            base("L", _numer++, maxŁadowność, wysokość, wagaWłasna, głębokość)
    {
        Niebezpieczny = niebezpieczny;
    }

    public void NotifyHazrd(string s)
    {
        Console.WriteLine($"Niebezpieczeństwo: {NumerSeryjny} {s}");
    }

    public override void Załaduj(double masa)
    {
        if (Niebezpieczny)
            MaxŁadowność = 0.5 * MaxŁadowność;
        else
            MaxŁadowność = 0.9 * MaxŁadowność;

        if (MasaŁadunku + masa > MaxŁadowność)
            NotifyHazrd($"Próba przekroczenia bezpiecznego wypełnienia kontenera {NumerSeryjny}");
        else
            MasaŁadunku += masa;
    }
}