using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class ConditionDetecter
    {
        public  DateTime _detectTime { get; }
        public List<Track> _detectningFligts { get; }

        public ConditionDetecter(List<Track> All_Flights)
        {
            _detectTime = DateTime.Now;
            _detectningFligts = All_Flights;
        }

    }
}
