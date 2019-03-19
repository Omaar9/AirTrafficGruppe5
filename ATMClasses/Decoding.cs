using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
namespace ATMClasses
{

    public class Decoding
    {
        public class TransponderReceiver : EventArgs
        {
            public string Signal { get; set; }
        }

        private ITransponderReceiver receiver;

        public Decoding(ITransponderReceiver myReceiver)
        {
            receiver = myReceiver;

            receiver.TransponderDataReady += DataHandler; //datahandler will be added to an internal list that the event keeps track of (when the owning class fires that event, all the delegates in the list will be called)

        }


        public void DataHandler(object o, RawTransponderDataEventArgs eventArgs)
        {
            List<string> recList = eventArgs.TransponderData;
           
            foreach (var er in recList)
            {
                Console.WriteLine(er);
            }


        }
    }
}
