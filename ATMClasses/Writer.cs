using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;


namespace ATMClasses
{
    public class Writer
    {

        public Writer(AirSpace airSpace)
        {
            airSpace.SplitCreated += onSplitCreated;
        }

        public void onSplitCreated(object source, SplitEvent condition)
        {
            Console.Clear();

            String[] l = new String[condition.ConditionDetecters.Count];

            for (int i = 0; i < condition.ConditionDetecters.Count; i++)
            {
                l[i] = "Flight are in DANGER";

                for (int j = 0; j < condition.ConditionDetecters[i]._detectingFligts.Count; j++)
                {
                    l[i] += condition.ConditionDetecters[i]._detectingFligts[j]._tag + ", ";
                }

                l[i] += condition.ConditionDetecters[i]._detectTime + ":" +
                        condition.ConditionDetecters[i]._detectTime.Millisecond;
            }

            for (int i = 0; i < l.Length; i++)
            {
                Console.WriteLine(l[i]);
            }

        }
    }
}
