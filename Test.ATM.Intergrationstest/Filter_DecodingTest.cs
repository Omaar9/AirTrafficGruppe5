using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using TransponderReceiver;
using NUnit.Framework;
using NSubstitute;

namespace Test.ATM.Intergrationstest
{
    class Filter_DecodingTest
    {
        private ITransponderReceiver reciever;
        private List<IUpdate> list;
        private IDecoding decoding;
        private Filter filter;
        private Decoding.UpdateEvent event_;
        private IUpdate track1;
        private IUpdate track2;
        private IUpdate track3;
        private IUpdate track4;


        [SetUp]
        public void SetUp()
        {
            reciever = Substitute.For<ITransponderReceiver>();

            decoding = new Decoding(reciever);
            filter = new Filter(decoding);

            list = new List<IUpdate>();
            event_ = new Decoding.UpdateEvent();

            track1 = Substitute.For<IUpdate>();
            track1._tag = "1111";
            track1._xcoordinate = 20000;
            track1._ycoordinate = 20000;
            track1._altitude = 500;
            track1.InAirspace = true;

            track2 = Substitute.For<IUpdate>();
            track2._tag = "1111";
            track2._xcoordinate = 20000;
            track2._ycoordinate = 22000;
            track2._altitude = 500;
            track2.InAirspace = true;

            track3 = Substitute.For<IUpdate>();
            track3._tag = "2222";
            track3._xcoordinate = 20000;
            track3._ycoordinate = 20000;
            track3._altitude = 500;
            track3.InAirspace = true;

            track4 = Substitute.For<IUpdate>();
            track4._tag = "2222";
            track4._xcoordinate = 20000;
            track4._ycoordinate = 21000;
            track4._altitude = 500;
            track4.InAirspace = true;

            list.Add(track1);
            list.Add(track2);
            list.Add(track3);
            list.Add(track4);

            event_.updatetracks = list;

            filter.OnUpdateCreated(decoding, event_);

            decoding._updateCreated += filter.OnUpdateCreated;

        }


        [Test]
        public void update_tracks()
        {
            Assert.That(decoding._dictionaryUpdate.Equals("1111"));
            
        }

        [Test]
        public void update_tracks2()
        {
            Assert.That(decoding._dictionaryUpdate.Equals("2222"));
        }
    }
}
