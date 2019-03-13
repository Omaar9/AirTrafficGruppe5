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
        private ITransponderReceiver receiver;

        Decoding(ITransponderReceiver myReceiver)
        {
            receiver = myReceiver;

            receiver.TransponderDataReady += DataHandler;
        }

        public void DataHandler(object o, RawTransponderDataEventArgs eventArgs)
        {
            List<string> recList = eventArgs.TransponderData;
        }
    }
}
