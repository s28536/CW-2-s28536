namespace DefaultNamespace;

public class Kontenerowiec
{
    private List<Kontener> kontenery = new List<Kontener>();
    
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

    public void DodajKontener(Kontener kontener)
    {
        if (kontenery.Count >= MaxLiczbaKontenerów)
        {
            throw new InvalidOperationException($"Nie można dodać więcej kontenerów");
        }

        double obecnaMasa = CałkowitaMasaŁadunku();
        double masaPoZaładunku = obecnaMasa + kontener.MasaŁadunku + kontener.WagaWłasna;
        double masaPoZaładunkuT = masaPoZaładunku / 1000;

        if (masaPoZaładunkuT > MaxWagaŁadunku)
        {
            throw new InvalidOperationException($"Nie można dodać konterera o tej wadze");
        }
        
        kontenery.Add(kontener);
    }

    public void DodajKontener(List<Kontener> kontenery)
    {
        foreach (var kontener in kontenery)
            DodajKontener(kontener);
    }

    public void UsuńKontener(string numerSeryjny)
    {
        Kontener doUsunięcia = kontenery.Find(c => c.NumerSeryjny == numerSeryjny);
        if (doUsunięcia == null)
            throw new ArgumentException($"Nie znalezniono kontenera na statku");
        else
        {
            kontenery.Remove(doUsunięcia);
        }
    }

    public void RozładujKontener(string numerSeryjny)
    {
        Kontener kontener = kontenery.Find(c => c.NumerSeryjny == numerSeryjny);
        if(kontener == null)
            throw new ArgumentException($"Nie znalezniono kontenera na statku");
        else
        {
            kontener.Opróżnij();
        }
    }


    public void ZamieńKontener(string numerSeryjny, Kontener kontener)
    {
        UsuńKontener(numerSeryjny);
        DodajKontener(kontener);
    }

    public void PrzenieśKontener(string numerSeryjny, Kontenerowiec stary, Kontenerowiec nowy)
    {
        Kontener kontener = kontenery.Find(c => c.NumerSeryjny == numerSeryjny);
        if(kontener == null)
            throw new ArgumentException($"Nie znalezniono kontenera na statku");
        
        nowy.DodajKontener(kontener);
        stary.kontenery.Remove(kontener);
    }

    private double CałkowitaMasaŁadunku()
    {
        double masa = 0;
        foreach (var kontener in kontenery)
        {
            masa += kontener.MasaŁadunku + kontener.WagaWłasna;
        }
        return masa;
    }

    public override string ToString()
    {
        return $"Kontenerowiec {Nazwa}, max prędkość {MaxPrędkość}, ilość kontenerów załoadowanych = {kontenery.Count}," +
               $"max ilość która może być załadowana {MaxLiczbaKontenerów} ";
    }

    public void WylistujKontenery()
    {
        Console.WriteLine($"Kontenery na statku {Nazwa}:");
        if (kontenery.Count == 0)
            Console.WriteLine("Brak kontenerow");
        else
        {
            foreach (var kontener in kontenery)
            {
                Console.WriteLine(kontener.ToString() );
            }
        }
    }
}