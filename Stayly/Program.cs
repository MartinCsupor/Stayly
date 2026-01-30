using MySqlConnector;
using Stayly.Database;
using Stayly.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;
using System.Text;


internal class Program
{
    public static readonly string connectionString = "Server=localhost;Database=stayly;User=root";
    public static DataTable adatok = new DataTable();
    public static List<Szallas> szallasList = new List<Szallas>();

    private static void Main(string[] args)
    {

        DatabaseServices.DBConnectionCheck(connectionString);
        SelectAll(connectionString, "szallas");
        SzallasFeltoltes(adatok, ref szallasList);
        OsszesKiiras(szallasList);
        SzallasFoglalas(szallasList);
        Elerheto(szallasList);
        EzernelTobb(szallasList, out int dragaDB);
        Console.WriteLine($"Összesen: {dragaDB} db 1000-nél drágább     szállás");
        ErtekeleseNagyobb4(szallasList);
        LegjobbErtekelesu(szallasList);
        SzallasokVarosSzerint(szallasList);
        SzallasFelvetel(adatok);
    }

    private static void SzallasFelvetel(DataTable adatok)
    {
        Console.WriteLine("\n--- Új szállás felvétele ---");

        Console.Write("Host neve: ");
        string hostName = Console.ReadLine().Trim();

        Console.Write("Szállás neve: ");
        string propertyName = Console.ReadLine().Trim();

        Console.Write("Város: ");
        string location = Console.ReadLine().Trim();

        Console.Write("Ár (pl. 18500): ");
        double price = Convert.ToDouble(Console.ReadLine().Trim());

        Console.Write("Értékelés (0–5): ");
        double rating = Convert.ToDouble(Console.ReadLine().Trim());

        Console.Write("Bejelentkezés ideje (pl. 14:00): ");
        string checkIn = Console.ReadLine().Trim();

        Console.Write("Kijelentkezés ideje (pl. 10:00): ");
        string checkOut = Console.ReadLine().Trim(); ;

        Console.Write("Elérhető? (1 = igen, 0 = nem): ");
        int elerheto = Convert.ToInt32(Console.ReadLine().Trim());

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
                        Console.WriteLine("Szállás sikeresen felvéve az adatbázisba!");
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
;       Console.WriteLine("Add meg a várost:");
        string varos = Console.ReadLine().Trim();
        bool talalhato = false;
        string PopertyName = null;
        double Price = 0;
        bool Avaibality = false;

        foreach (var sz in lista)
        {
            if (sz.Location.Equals(varos, StringComparison.OrdinalIgnoreCase))
            {
                talalhato = true;
                PopertyName = sz.PopertyName;
                Price = sz.Price;
                Avaibality = sz.Avaibality;
            }
        }

        Console.ForegroundColor = Avaibality ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(
             talalhato
                 ?
                 (
                     $"{PopertyName} - {Price} - {(Avaibality ? "Igen" : "Nem")}"
                 )
                 :
                (
                    "Nem található szállás ebben a városban!"
                )
         );
        Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{legjobb.PopertyName} - Értékelés: {legjobb.Rating}");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,-5} | {1,-40} | {2,10}/5", sz.Id, sz.PopertyName, sz.Rating);
                Console.ResetColor();
            }
        }
    }

    private static void Elerheto(List<Szallas> szallasLis)
    {
        Console.WriteLine();
        Console.WriteLine("Elérhető szállások");

        foreach (Szallas sz in szallasList)
        {
            if (sz.Avaibality)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,-3} | {1,-35} | {2,-20}", sz.Id, sz.PopertyName, sz.Location);
                Console.ResetColor();
            }
        }
    }

    private static void EzernelTobb(List<Szallas> szallasLis, out int darab)
    {
        darab = 0;

        Console.WriteLine();
        Console.WriteLine("1000-nél drágább szállások");

        foreach (Szallas sz in szallasList)
        {
            if (sz.Price > 1000)
            {
                darab++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,-5} | {1,-40} | {2,15:N0}", sz.Id, sz.PopertyName, sz.Price);
                Console.ResetColor();
            }
        }
    }

    private static void SzallasFoglalas(List<Szallas> szallasList)
    {
        Console.WriteLine("Add meg a foglalandó szállás nevét:");
        string keresettNev = Console.ReadLine().Trim();

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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nincs ilyen nevű szállás.");
            Console.ResetColor();
            return;
        }

        if (talaltSzallas.Avaibality)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            talaltSzallas.Avaibality = false;
            Console.WriteLine("Foglalás sikeres!");
            Console.WriteLine($"Bejelentkezés: {talaltSzallas.CheckInTime}");
            Console.WriteLine($"Kijelentkezés: {talaltSzallas.CheckOutTime}");
            Console.ResetColor();

            string filePath = "foglalt_szallasok.csv";

            using StreamWriter writer = new StreamWriter(filePath, true);

            writer.WriteLine("Id;SzallasNev;Varos;Ar;Ertekeles;CheckIn;CheckOut");
            writer.WriteLine($"{talaltSzallas.Id};{talaltSzallas.PopertyName};{talaltSzallas.Location};{talaltSzallas.Price};{talaltSzallas.Rating};{talaltSzallas.CheckInTime};{talaltSzallas.CheckOutTime}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ez a szállás már nem elérhető.");
            Console.ResetColor();
        }
    }


    private static void OsszesKiiras(List<Szallas> szallasList)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(
            "{0,-13} | {1,-25} | {2,-32} | {3,-25} | {4,20:N0} Ft | {5,6} | {6,-15} | {7,-15} | {8,-15}",
            "ID", "Host", "Szállás", "Város", "Ár", "Értékelés", "Elérhető", "Becsekkolás", "Kicsekkolás"
        );
        Console.WriteLine(new string('-', 205));
        Console.ResetColor();

        foreach (var szallas in szallasList)
        {
            Console.ForegroundColor = szallas.Avaibality ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(szallas.ToString());
            Console.ResetColor();
        }
    }

    private static void SzallasFeltoltes(DataTable adatok, ref List<Szallas> szallasList)
    {
        foreach (DataRow row in adatok.Rows)
        {
            Szallas szallas = new Szallas();

            szallas.Id = Convert.ToInt32(row[0]);
            szallas.HostName = row[1].ToString();
            szallas.PopertyName = row[2].ToString();
            szallas.Location = row[3].ToString();
            szallas.Price = Convert.ToDouble(row[4]);
            szallas.Rating = Convert.ToInt32(row[5]);
            szallas.CheckInTime = row[6].ToString();
            szallas.CheckOutTime = row[7].ToString();
            szallas.Avaibality = Convert.ToBoolean(Convert.ToInt32(row[8]));

            szallasList.Add(szallas);
        }
    }

    private static void SelectAll(string connectionString, string v)
    {
        adatok = DatabaseServices.getAllData(connectionString, "szallas");
    }
}