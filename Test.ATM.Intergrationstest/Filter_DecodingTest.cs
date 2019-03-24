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
        private ITransponderReceiver transponder;
        private List<IUpdate> list_;
        private IDecoding decoding_;
        private Filter filter_;
        private Decoding.UpdateEvent event_;
        private IUpdate track1;
        private IUpdate track2;
        private IUpdate track3;
        private IUpdate track4;


        [SetUp]
        public void SetUp()
        {
            transponder = Substitute.For<ITransponderReceiver>();

            decoding_ = new Decoding(transponder);
            filter_ = new Filter(decoding_);

            list_ = new List<IUpdate>();
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

            list_.Add(track1);
            list_.Add(track2);
            list_.Add(track3);
            list_.Add(track4);

            event_.updatetracks = list_;

            filter_.onUpdateCreated(decoding_, event_);

            decoding_._updateCreated += filter_.onUpdateCreated;

        }


        [Test]
        public void update_tracks()
        {
            Assert.That(decoding_.trackDic.Equals("1111"));
        }

        [Test]
        public void update_tracks2()
        {
            Assert.That(decoding_.trackDic.Equals("2222"));
        }
    }
}
