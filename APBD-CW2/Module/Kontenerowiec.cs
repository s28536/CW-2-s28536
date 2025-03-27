namespace DefaultNamespace;

public class Kontenerowiec
{
    private List<Kontener> kontenery;
    
    public string Nazwa { get; set; }
    public double MaxPrędkość { get; private set; }
    public int MaxLiczbaKontenerów { get; private set; }
    public double MaxWagaŁadunku { get; private set; }

    public Kontenerowiec(string nazwa, double maxPrędkość, int maxLiczbaKontenerów, double maxWagaŁadunku)
    {
        Nazwa = nazwa;
        MaxPrędkość = maxPrędkość;
        MaxLiczbaKontenerów = maxLiczbaKontenerów;
        MaxWagaŁadunku = maxWagaŁadunku;
    }
    
}