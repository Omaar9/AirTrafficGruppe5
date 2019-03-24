using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATMClasses
{
    public class TransponderReceiver
    {

    }

    public interface ITransponderReceiver
    {
        event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
    }
    public class TransponderReceiverFactory
    {
        public static ITransponderReceiver CreateTransponderDataReceiver { get; }
    }
}
