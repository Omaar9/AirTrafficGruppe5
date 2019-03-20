using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATMClasses
{
    public class Update
    {
        //Attributter
        public DateTime _date { get; set; }
        public double _xcoordinate { get; set; }
        public double _ycoordinate { get; set; }
        public string _tag { get; set; }
        public double _altitude { get; set; }
        public bool _airspace { get; set; }

        //Constructor
        public Update(DateTime date, double X, double Y, string tag, double altitude)
        {
            _date = date;
            _xcoordinate = X;
            _ycoordinate = Y;
            _tag = tag;
            _altitude = altitude;
            _airspace = FlightsInSpace(X, Y, altitude);
        }

        //Metode
        public bool FlightsInSpace(double X, double Y, double altitude)
        {
            if (X >= 10000 && X <= 80000 && Y >= 80000 && Y <= 90000 && altitude >= 500 && altitude <= 20000)
            {
                return true;
            }

            return false;

        }


    }

}
