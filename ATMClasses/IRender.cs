using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface IRender
    {
        double direction_ { get; set; }
        DateTime Date { get; set; }
        double X_coordinates { get; set; }
        double Y_coordinates { get; set; }
        string Tag_ { get; set; }
        double Altitude_ { get; set; }
        bool Velocity { get; set; }
    }
}
