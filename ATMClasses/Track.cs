using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    class Track : ITrack
    {
        public double direction_ { get; set; }
        public DateTime Date { get; set; }
        public double X_coordinates { get; set; }
        public double Y_coordinates { get; set; }
        public string Tag_ { get; set; }
        public double Altitude_ { get; set; }
        public double Velocity { get; set; }

        public Track(IUpdate previousTrack, IUpdate currentTrack)
        {
            this.Tag_ = currentTrack._tag;
            X_coordinates = currentTrack._xcoordinate;
            Y_coordinates = currentTrack._ycoordinate;
            this.Altitude_ = currentTrack._altitude;
            this.Date = currentTrack._date;


            Velocity = CalculateVelocity(previousTrack._xcoordinate, X_coordinates, previousTrack._ycoordinate, Y_coordinates, previousTrack._date,
                Date);

            direction_ = CalculateDegree(previousTrack._xcoordinate, X_coordinates, previousTrack._ycoordinate, Y_coordinates);
        }

        public double Distance(double x1, double x2, double y1, double y2)
        {
            double hyp = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            return hyp;
        }

        public double CalculateVelocity(double x1, double x2, double y1, double y2, DateTime date1, DateTime date2)
        {
            double hyp = Distance(x1, x2, y1, y2);
            TimeSpan span = date2 - date1;
            double timedef = span.TotalMilliseconds / 1000;
            double v = hyp / timedef;
            return v;
        }

        public double CalculateDegree(double x1, double x2, double y1, double y2)
        {
            double xDiff = x2 - x1;
            double yDiff = y2 - y1;

            double deg = Math.Atan(xDiff / yDiff) * 180 / Math.PI;

            if (xDiff > 0 && yDiff < 0)
                return -deg + 90;

            if (xDiff < 0 && yDiff < 0)
                return deg + 180;

            if (xDiff < 0 && yDiff > 0)
                return -deg + 270;

            if (xDiff < 0 && yDiff == 0)
                return deg + 360;

            if (xDiff == 0 && yDiff < 0)
                return deg + 180;

            return deg;
        }

    }
}
