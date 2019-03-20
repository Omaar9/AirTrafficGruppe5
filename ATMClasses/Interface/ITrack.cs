using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface ITrack
    {
        double _direction { get; set; }
        DateTime _date { get; set; }
        double _xcoordinates { get; set; }
        double _ycoordinates { get; set; }
        string _tag { get; set; }
        double _altitude { get; set; }
        bool _velocity { get; set; }
    }
}
