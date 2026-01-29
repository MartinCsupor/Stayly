using MySqlConnector;
using Stayly.Database;
using Stayly.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;


internal class Program
{
    public static readonly string connectionString = "Server=localhost;Database=stayly;User=root";
    public static DataTable adatok = new DataTable();
    public static List<Szallas> szallasList = new List<Szallas>();

    private static void Main(string[] args)
    {
       
        DatabaseServices.DBConnectionCheck(connectionString);
        SelectAll(connectionString, "szallas");
        SzallasFeltoltes(adatok);
        SzallasFoglalas(szallasList);
        Elerheto(szallasList);
        EzernelTobb(szallasList);
        ErtekeleseNagyobb4(szallasList);
        LegjobbErtekelesu(szallasList);
        SzallasokVarosSzerint(szallasList);
        SzallasFelvetel(adatok);



    }

    private static void SzallasFelvetel(DataTable adatok)
    {
        Console.WriteLine("\n--- Új szállás felvétele ---");

        Console.Write("Host neve: ");
        string hostName = Console.ReadLine();

        Console.Write("Szállás neve: ");
        string propertyName = Console.ReadLine();

        Console.Write("Város: ");
        string location = Console.ReadLine();

        Console.Write("Ár (pl. 18500): ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Értékelés (0–10): ");
        double rating = Convert.ToDouble(Console.ReadLine());

        Console.Write("Bejelentkezés ideje (pl. 14:00): ");
        string checkIn = Console.ReadLine();

        Console.Write("Kijelentkezés ideje (pl. 10:00): ");
        string checkOut = Console.ReadLine();

        Console.Write("Elérhető? (1 = igen, 0 = nem): ");
        int elerheto = Convert.ToInt32(Console.ReadLine());

        string query = "INSERT INTO szallas (hostName, popertyName, location, price, rating, checkInTime, checkOutTime, elerhetoseg) " +
                       "VALUES (@host, @name, @loc, @price, @rating, @checkIn, @checkOut, @ava)";

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@host", hostName);
                    cmd.Parameters.AddWithValue("@name", propertyName);
                    cmd.Parameters.AddWithValue("@loc", location);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@rating", rating);
                    cmd.Parameters.AddWithValue("@checkIn", checkIn);
                    cmd.Parameters.AddWithValue("@checkOut", checkOut);
                    cmd.Parameters.AddWithValue("@ava", elerheto);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Console.WriteLine(" Szállás sikeresen felvéve az adatbázisba!");
                    }
                    else
                    {
                        Console.WriteLine("Nem sikerült a beszúrás!");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Hiba történt: {ex.Message}");
        }
    }

    private static void SzallasokVarosSzerint(List<Szallas> lista)
    {
        Console.WriteLine()
;        Console.WriteLine("Add meg a várost:");
        string varos = Console.ReadLine();

        foreach (var sz in lista)
        {
            if (sz.Location.Equals(varos, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{sz.PopertyName} - {sz.Price} - {sz.Avaibality}");
            }
        }
    }


    private static void LegjobbErtekelesu(List<Szallas> szallasLis)
    {
        Console.WriteLine();
        Szallas legjobb = null;

        foreach (Szallas sz in szallasList)
        {
            if (legjobb == null || sz.Rating > legjobb.Rating)
            {
                legjobb = sz;
            }
        }

        if (legjobb != null)
        {
            Console.WriteLine("Legjobb értékelésű szállás");
            Console.WriteLine($"{legjobb.PopertyName} - Értékelés: {legjobb.Rating}");
        }
    }

    private static void ErtekeleseNagyobb4(List<Szallas> szallasLis)
    {
        Console.WriteLine();
        Console.WriteLine("4 feletti értékelésű szállások ");

        foreach (Szallas sz in szallasList)
        {
            if (sz.Rating > 4)
            {
                Console.WriteLine($"{sz.PopertyName} - Értékelés: {sz.Rating}");
            }
        }
    }

    private static void Elerheto(List<Szallas> szallasLis)
    {
        Console.WriteLine();
        Console.WriteLine(" Elérhető szállások");

        foreach (Szallas sz in szallasList)
        {
            if (sz.Avaibality)
            {
                Console.WriteLine($"{sz.PopertyName} ({sz.Location})");
            }
        }
    }

    private static void EzernelTobb(List<Szallas> szallasLis)
    {
        Console.WriteLine();
        Console.WriteLine("1000-nél drágább szállások");

        foreach (Szallas sz in szallasList)
        {
            if (sz.Price > 1000)
            {
                Console.WriteLine($"{sz.PopertyName} - Ár: {sz.Price}");
            }
        }

    }

    private static void NewMethod()
    {
       // SzallasFeltoltes(adatok);
        OsszesKiiras(szallasList);
       // SzallasFoglalas(szallasList);
    }

    private static void SzallasFoglalas(List<Szallas> szallasList)
    {
        Console.WriteLine("Add meg a foglalandó szállás nevét:");
        string keresettNev = Console.ReadLine();

        Szallas talaltSzallas = null;

        foreach (var item in szallasList)
        {
            if (item.PopertyName.Equals(keresettNev, StringComparison.OrdinalIgnoreCase))
            {
                talaltSzallas = item;
                break;
            }
        }

        if (talaltSzallas == null)
        {
            Console.WriteLine("Nincs ilyen nevű szállás.");
            return;
        }

        if (talaltSzallas.Avaibality)
        {
            talaltSzallas.Avaibality = false;
            Console.WriteLine("Foglalás sikeres!");
            Console.WriteLine($"Bejelentkezés: {talaltSzallas.CheckInTime}");
            Console.WriteLine($"Kijelentkezés: {talaltSzallas.CheckOutTime}");
        }
        else
        {
            Console.WriteLine("Ez a szállás már nem elérhető.");
        }
    }


    private static void OsszesKiiras(List<Szallas> szallasList)
    {
        foreach (var szallas in szallasList)
        {
            Console.WriteLine(szallas.ToString());
        }
    }

    private static void SzallasFeltoltes(DataTable adatok)
    {
        foreach (DataRow row in adatok.Rows) 
        {
            Szallas szallas = new Szallas();

            szallas.Id = Convert.ToInt32(row[0]);
            szallas.HostName = row[1].ToString();
            szallas.PopertyName =row[2].ToString();
            szallas.Location =row[3].ToString();
            szallas.Price = Convert.ToDouble(row[4]);
            szallas.Rating = Convert.ToInt32(row[5]);
            szallas.CheckInTime = row[6].ToString();
            szallas.CheckOutTime = row[7].ToString();
            szallas.Avaibality = Convert.ToBoolean(row[8]);

            szallasList.Add(szallas);
        }
    }

    private static void SelectAll(string connectionString, string v)
    {
        adatok = DatabaseServices.getAllData(connectionString, "szallas");
    }
}