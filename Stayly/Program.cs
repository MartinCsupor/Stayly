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
        OsszesKiiras(szallasList);
        SzallasFoglalas(szallasList);
    }

    private static void SzallasFoglalas(List<Szallas> szallasList)
    {
        Console.WriteLine("Add meg a foglalandó szállás nevét");
        var szallas = Console.ReadLine();

        foreach (var item in szallasList)
        {
            
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