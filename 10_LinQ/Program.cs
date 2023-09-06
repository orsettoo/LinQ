class Kisi
{
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public int Yas { get; set; }
    public bool Cinsiyet { get; set; }
}
class KisiModel
{
    public string TamAdi { get; set; }
}
class Program
{
    static void CizgiCiz() => Console.WriteLine("----------------------------------------------");

    static int[] sayilar = { 12, 45, 89, 5, 6, 65, 2, 31, 2, 45 };
    static string[] isimler = { "ismail", "özge", "arda", "kübra", "berat", "can", "şayma", "lizge" };

    static List<Kisi> kisiler = new List<Kisi>()
    {
        new Kisi{Adi="Özge",  Soyadi="Doblan",  Yas=20, Cinsiyet=true },
        new Kisi{Adi="Lizge", Soyadi="Diri",    Yas=19, Cinsiyet=true},
        new Kisi{Adi="İsmail",Soyadi="Türkmen",  Yas=25, Cinsiyet =false},
        new Kisi{Adi="Berat", Soyadi="Genç",    Yas=26, Cinsiyet = false},
        new Kisi{Adi="Kübra", Soyadi="Barman",  Yas=18, Cinsiyet =true},
        new Kisi{Adi="Arda",  Soyadi="Büyükdoluca",  Yas=28, Cinsiyet = false},
        new Kisi{Adi="Seyma", Soyadi="Başnak",  Yas=17, Cinsiyet =true},
    };
    static void Main(string[] args)
    {
        var query1 = from k in kisiler
                     select new KisiModel
                     {
                         TamAdi = k.Adi + " " + k.Soyadi
                     };
        query1.ToList().ForEach(x => Console.WriteLine(x.TamAdi));
    }

    private static void LINQ6()
    {
        var query1 = from per in kisiler
                         //orderby per.Yas
                     select new
                     {
                         Name = per.Adi,
                         Surname = per.Soyadi
                     };
        foreach (var item in query1.OrderBy(x => x.Name))
        {
            Console.WriteLine(item.Name);
        }
    }

    private static void LINQ5()
    {
        var query1 = from k in kisiler
                     orderby k.Adi
                     select k;
        foreach (var item in query1)
        {
            Console.WriteLine(item.Adi);
        }
    }

    private static void LinQ4_Kisiler()
    {
        var query3 = kisiler.OrderBy(person => person.Adi);
        query3.ToList().ForEach(x =>
        {
            Console.Write(x.Cinsiyet ? "Bayan " : "Bay ");
            Console.Write($"{x.Adi} {x.Soyadi.ToUpper()} \t");
            Console.Write(x.Yas > 20 ? "*" : x.Yas);
            Console.WriteLine();
        });
    }

    private static void LinQ3_Kisiler()
    {
        var query1 = kisiler.OrderBy(x => x.Adi);
        query1.ToList().ForEach(x => Console.WriteLine(x.Adi));
        CizgiCiz();

        var query2 = kisiler
            .OrderBy(x => x.Adi)
            .Where(kisi => kisi.Cinsiyet && kisi.Yas > 18);
        //.Where(kisi=>kisi.Cinsiyet==true);

        query2.ToList().ForEach(per =>
        {
            Console.Write(per.Adi.ToUpper());
            Console.Write(" " + per.Yas);
            Console.WriteLine();
        });
        CizgiCiz();
    }

    private static void LinQ2()
    {
        isimler.OrderBy(x => x).ToList().ForEach(isim =>
        {
            Console.Write(isim);
            Console.WriteLine(" " + isim.Length);
        });
        CizgiCiz();

        var query1 = isimler.Where(name => name.Contains("a"));
        query1.ToList().ForEach(isim => Console.WriteLine(isim));
        CizgiCiz();

        var query2 = isimler.Where(name => name.Contains("a") && name.Length > 4);
        query2.ToList().ForEach(isim => Console.WriteLine(isim));



    }

    private static void Linq1()
    {
        var query1 = sayilar.OrderBy(x => x);
        foreach (int i in query1)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("-------------------");

        //var query2 = query1.Distinct();
        foreach (int i in query1.Distinct())
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("------------------------------");
        query1.ToList().ForEach(sayi =>
        {
            Console.Write(sayi);
            Console.WriteLine("---" + sayi * sayi);
        });
    }
}
