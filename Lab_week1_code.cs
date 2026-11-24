using System;
using System.Collections.Generic;
using System.Linq;

enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

class Cihaz
{
    public int Kimlik { get; }
    public string Ad { get; }
    public CihazTuru Tur { get; }
    public bool AcikMi { get; private set; }

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false; 
    }

    public void Ac()
    {
        AcikMi = true;
    }

    public void Kapat()
    {
        AcikMi = false;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine($"Kimlik: {Kimlik} | Ad: {Ad} | Tür: {Tur} | Durum: {(AcikMi ? "Açık" : "Kapalı")}");
    }
}
class Program
{
    static void Main()
    {
        List<Cihaz> cihazlar = new List<Cihaz>
        {
            new Cihaz(1, "Lamba1", CihazTuru.Lamba),
            new Cihaz(2, "Klima2", CihazTuru.Klima),
            new Cihaz(3, "Sensör", CihazTuru.GuvenlikSistemi)
        };
        while (true)
        {
            Console.WriteLine("\n--- AKILLI EV MENÜSÜ ---");
            Console.WriteLine("1. Cihazları listele");
            Console.WriteLine("2. Yeni cihaz ekle");
            Console.WriteLine("3. Cihaz aç");
            Console.WriteLine("4. Cihaz kapat");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Listele(cihazlar);
                    break;
                case "2":
                    CihazEkle(cihazlar);
                    break;
                case "3":
                    DurumDegistir(cihazlar, true);
                    break;
                case "4":
                    DurumDegistir(cihazlar, false);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }


        }
    }
    static void Listele(List<Cihaz> cihazlar)
    {
        if (cihazlar.Count == 0)
        {
            Console.WriteLine("Kayıtlı cihaz yok.");
            return;
        }
        foreach (Cihaz c in cihazlar)
            c.BilgileriGoster();
    }

    static void CihazEkle(List<Cihaz> cihazlar)
    {
        Console.Write("Kimlik: ");
        if (!int.TryParse(Console.ReadLine(), out int kimlik))
        {
            Console.WriteLine("Geçersiz kimlik!");
            return;
        }

        
        if (cihazlar.Any(c => c.Kimlik == kimlik))
        {
            Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz zaten var!");
            return;
        }

        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.WriteLine("Tür seçin: 1-Lamba, 2-Klima, 3-GuvenlikSistemi");
        CihazTuru tur;
        switch (Console.ReadLine())
        {
            case "1": tur = CihazTuru.Lamba; break;
            case "2": tur = CihazTuru.Klima; break;
            case "3": tur = CihazTuru.GuvenlikSistemi; break;
            default:
                Console.WriteLine("Geçersiz tür!");
                return;
        }

        cihazlar.Add(new Cihaz(kimlik, ad, tur));
        Console.WriteLine("Cihaz eklendi (kapalı durumda).");
    }

    static void DurumDegistir(List<Cihaz> cihazlar, bool ac)
    {
        Console.Write("Cihaz kimliği: ");
        if (!int.TryParse(Console.ReadLine(), out int kimlik))
        {
            Console.WriteLine("Geçersiz kimlik!");
            return;
        }

        Cihaz cihaz = cihazlar.FirstOrDefault(c => c.Kimlik == kimlik);

        
        if (cihaz == null)
        {
            Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz bulunamadı!");
            return;
        }

        if (ac) cihaz.Ac();
        else cihaz.Kapat();

        Console.WriteLine(ac ? "Cihaz açıldı." : "Cihaz kapatıldı.");
        cihaz.BilgileriGoster();
    }
   
}
