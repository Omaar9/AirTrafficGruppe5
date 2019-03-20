using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class Track : ITrack
    {
        double _direction { get; set; }
        DateTime _date { get; set; }
        double _xcoordinate { get; set; }
        double _ycoordinate { get; set; }
        string _tag { get; set; }
        double _altitude { get; set; }
        bool _velocity { get; set; }
    }
}
