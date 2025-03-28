using DefaultNamespace;

class Program
{
    public static void Main(string[] args)
    {
        var płyny1 = new Kontener_na_płyny(500,200,100,100,false);
        var gaz1 = new Kontener_na_gaz(300, 200, 100, 100, 10);
        var chłod1 = new Kontener_chłodniczy(300, 200, 200, 200, "mleko",
            -5, 10);
        var kontenerowiec1 = new Kontenerowiec("Płotka", 10, 100, 100);
        
        gaz1.Załaduj(10);
        
        List<Kontener> kontenery = new List<Kontener>();
        kontenery.Add(płyny1);
        kontenery.Add(chłod1);
        
        kontenerowiec1.DodajKontener(gaz1);
        kontenerowiec1.DodajKontener(kontenery);
        
        kontenerowiec1.UsuńKontener("KON-C-1");
        
        kontenerowiec1.RozładujKontener("KON-L-1");
        
        var gaz2 = new Kontener_na_gaz(300, 200, 100, 100, 10);
        kontenerowiec1.ZamieńKontener("KON-L-1", gaz2);
        
        Console.WriteLine(kontenerowiec1.ToString());

        var kontenerowiec2 = new Kontenerowiec("Szerszeń", 0, 1, 1);
        kontenerowiec1.PrzenieśKontener("KON-G-2", kontenerowiec1,kontenerowiec2);

        Console.WriteLine(gaz2.ToString());
        Console.WriteLine();
        Console.WriteLine(kontenerowiec2.ToString());
        kontenerowiec2.WylistujKontenery();

    }
}