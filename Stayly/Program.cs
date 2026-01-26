using Stayly.Database;
using Stayly.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

internal class Program
{
    public static readonly string connectionString = "Server=localhost;Database=stayly;User=root";
    public static DataTable adatok = new DataTable();
    public static List<Szallas> szallasList = new List<Szallas>();
    private static void Main(string[] args)
    {
        DatabaseServices.DBConnectionCheck(connectionString);
        SelectAll(connectionString, "szallas");
        Elerheto(szallasList);
        EzernelTobb(szallasList);
        ErtekeleseNagyobb4(szallasList);
        LegjobbErtekelesu(szallasList);
        ArTartomany(szallasList);
    }

    private static void ArTartomany(List<Szallas> szallasList,double max,double min)
    {

        Console.WriteLine($"Ár {min} - {max} között");

        foreach (Szallas sz in szallasList)
        {
            if (sz.Price >= min && sz.Price <= max)
            {
                Console.WriteLine($"{sz.PopertyName} - {sz.Price}");
            }
        }
    }

    private static void LegjobbErtekelesu(List<Szallas> szallasLis)
    {

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
        SzallasFeltoltes(adatok);
    }

    private static void SzallasFeltoltes(DataTable adatok)
    {

    }

    private static void SelectAll(string connectionString, string v)
    {
        adatok = DatabaseServices.getAllData(connectionString, "szallas");
    }
}