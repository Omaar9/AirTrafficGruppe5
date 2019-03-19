using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class ConditionDetecter
    {
        public  DateTime detectTime_ { get; }
        public List<Render> DetectningFligts_ { get; }

        public ConditionDetecter(List<Render> All_Flights)
        {
            detectTime_=DateTime.Now;
            DetectningFligts_ = All_Flights;
        }

    }
}
