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
        public  DateTime Date { get; set; }
        public double X_coordinates { get; set; }
        public double Y_coordinates { get; set; }
        public string Tag_ { get; set; }
        public double Altitude_ { get; set; }
        public bool Airspace_ { get; set; }

        //Constructor
        public Update(DateTime date, double X, double Y, string tag, double altitude)
        {
            Date = date;
            X_coordinates = X;
            Y_coordinates = Y;
            Tag_ = tag;
            Altitude_ = altitude;
            Airspace_ = FlightsInSpace(X, Y, altitude);
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
