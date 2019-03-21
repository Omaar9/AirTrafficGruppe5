using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class ConditionDetecter
    {
        public List<ITrack> _detectingFligts { get; }
        public  DateTime _detectTime { get; }
        

        public ConditionDetecter(List<ITrack> All_Flights)
        {
            _detectingFligts = All_Flights;
            _detectTime = DateTime.Now;
        }

    }
}
