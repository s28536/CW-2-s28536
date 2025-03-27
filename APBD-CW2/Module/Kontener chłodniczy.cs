namespace DefaultNamespace;

public class Kontener_chłodniczy : Kontener
{
    private static int _numer = 1;
    public string RodzajProduktu { get; private set; }
    public double Temperatura { get; private set; }
    public double MinimalnaTemperatura { get; private set; }
    
    public Kontener_chłodniczy(string typ, int numer, double maxŁadowność, double wysokość, double wagaWłasna,
                        double głębokość, string rodzajProduktu, double minimalnaTemperatura, double temperatura) : 
                        base("C", _numer++, maxŁadowność, wysokość, wagaWłasna, głębokość)
    {
        RodzajProduktu = rodzajProduktu;
        Temperatura = minimalnaTemperatura;
        MinimalnaTemperatura = minimalnaTemperatura;
    }
    
}