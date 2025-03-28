namespace DefaultNamespace;

public abstract class Kontener
{
    public double MasaŁadunku { get; protected set; }
    public double Wysokość { get; protected set; }
    public double WagaWłasna { get; protected set; }
    public double Głębokość { get; protected set; }
    public string NumerSeryjny { get; private set; }
    public double MaxŁadowność { get; protected set; }

    protected Kontener(string typ, int numer, double maxŁadowność,
                        double wysokość, double wagaWłasna, double głębokość)
    {
        NumerSeryjny = StwórzNumerSeryjny(typ, numer);
        MaxŁadowność = maxŁadowność;
        Wysokość = wysokość;
        WagaWłasna = wagaWłasna;
        Głębokość = głębokość;
        
    }

    private string StwórzNumerSeryjny(string typ, int numer)
    {
        return $"KON-{typ}-{numer}";
    }

    public virtual void Opróżnij()
    {
        MasaŁadunku = 0;
    }

    public virtual void Załaduj(double masa)
    {
        if (MasaŁadunku + masa > MaxŁadowność)
        {
            throw new OverflillException(
                $"Próba załadowania {masa}kg w kontee {NumerSeryjny}: NIE POWIODŁA SIĘ!!!!");
        }
        else
        {
            MasaŁadunku += masa;
        }
    }

    public override string ToString()
    {
        return $"Kontener {NumerSeryjny} o masie {WagaWłasna + MasaŁadunku}";
    }
}

public class OverflillException : Exception
{
    public OverflillException(string s) : base(s) { }
}