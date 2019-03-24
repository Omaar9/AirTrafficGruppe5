using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATMClasses
{

    public class Decoding : IDecoding
    {

        private ITransponderReceiver _receiver;
        public List<IUpdate> _ftracks { get; set; }
        public event EventHandler<UpdateEvent> _updateCreated;
        public object trackDic { get; set; }


        public Decoding(ITransponderReceiver myReceiver)
        {
            _receiver = myReceiver;

            _receiver.TransponderDataReady += DataHandler; //datahandler will be added to an internal list that the event keeps track of (when the owning class fires that event, all the delegates in the list will be called)

        }


        public void DataHandler(object o, RawTransponderDataEventArgs eventArgs)
        {
            List<string> recList = eventArgs.TransponderData;
            _ftracks = new List<IUpdate>();
            //  foreach (var track in e.TransponderData)
            foreach (var track in recList)
            {
                Console.WriteLine(track);
            }
            onUpdateCreated(_ftracks);
        }

        public void Seperater(String track)
        {
            string[] transData = track.Split(';');

            DateTime dt = DateTime.ParseExact(transData[4], "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);


            IUpdate updateTrack = new Update(
                transData[0],
                Convert.ToDouble(transData[1]),
                Convert.ToDouble(transData[2]),
                Convert.ToDouble(transData[3]),
                dt
            );

            _ftracks.Add(updateTrack);

        }

        protected virtual void onUpdateCreated(List<IUpdate> utrack)
        {
            _updateCreated?.Invoke(this, new UpdateEvent() { updatetracks = utrack });
        }
            
           
        public class UpdateEvent : EventArgs
        {
            public List<IUpdate> updatetracks { get; set; }
        }

    }
}
