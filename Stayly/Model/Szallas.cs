using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stayly.Model
{
    internal class Szallas
    {
        private int _id;
        private string _hostName;
        private string _popertyName;
        private string _location;
        private double _price;
        private int _rating;
        private bool _avaibality;
        private string _checkInTime;
        private string _checkOutTime;

        public int Id { get => _id; set => _id = value; }
        public string HostName { get => _hostName; set => _hostName = value; }
        public string PopertyName { get => _popertyName; set => _popertyName = value; }
        public string Location { get => _location; set => _location = value; }
        public double Price { get => _price; set => _price = value; }
        public int Rating
        {
            get => _rating;
            set
            {
                if (value <= 5 && value > 0)
                {
                    _rating = value;
                }
            }
        }
        public bool Avaibality { get => _avaibality; set => _avaibality = value; }
        public string CheckInTime { get => _checkInTime; set => _checkInTime = value; }
        public string CheckOutTime { get => _checkOutTime; set => _checkOutTime = value; }
        public Szallas(int id, string hostName, string popertyName, string location, double price, int rating, bool avaibality, string checkInTime, string checkOutTime)
        {
            Id = id;
            HostName = hostName;
            PopertyName = popertyName;
            Location = location;
            Price = price;
            Rating = rating;
            Avaibality = avaibality;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
        }

        public Szallas() 
        {}
    }
}
