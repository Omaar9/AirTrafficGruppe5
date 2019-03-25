using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ATMClasses;
using ATMClasses.Interface;


namespace Test.ATM.Unitest
{
    public class DecodingTest
    {
        private TransponderReceiver _receiver;
        private List<IUpdate> _ftracks;
        public event EventHandler<UpdateEvent> _updateCreated;
        private TransponderReceiver _fakeData;
        private Decoding _uut;
        private List<string> list;
        private int _eventCalled;

        [SetUp]

        public void SetUp()
        {
            _eventCalled = 0;
            list = new List<string>();
            _receiver = Substitute.For<ITransponderReciever>();
            _ftracks = new List<IUpdate>();
            _uut = new Decoding(_receiver);
            list.Add("Test;111;222;333;20190325135320120");
            _fakeData = new TransponderReceiverDataEventArgs(list);

            _uut._updateCreated += (o, args) => _ftracks = args.updatetracks;
            {
                ++_eventCalled;
            }
        }

        [Test]

        public void Split_Objekt()
        {
            IUpdate compareUpdate = Substitute.For<IUpdate>();
            compareUpdate._tag = "Test1";
            compareUpdate._xcoordinate = 111;
            compareUpdate._ycoordinate = 222;
            compareUpdate._altitude = 333;
            compareUpdate._date = DateTime.ParseExact("20190325135320120", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            _receiver.TransponderDataReady += Raise.EventWith(_fakeData);

            Assert.That(_ftracks[0]._tag, Is.EqualTo(compareUpdate._tag));
            Assert.That(_ftracks[0]._xcoordinate, Is.EqualTo(compareUpdate._xcoordinate));
            Assert.That(_ftracks[0]._ycoordinate, Is.EqualTo(compareUpdate._ycoordinate));
            Assert.That(_ftracks[0]._altitude, Is.EqualTo(compareUpdate._altitude));
            Assert.That(_ftracks[0]._date, Is.EqualTo(compareUpdate._date));
        }

        [Test]
        public void OneString_Raises_OneEvent()
        {
            _receiver.TransponderDataReady += Raise.EventWith(_fakeData);
            Assert.That(_eventCalled, Is.EqualTo(1));
        }

        [Test]
        public void MoreStrings_Raises_OneEvent()
        {
            _fakeData.TransponderData.Add("Test2;222;333;444;20200325135320120");
            _fakeData.TransponderData.Add("Test3;222;333;444;20210325135320120");
            _receiver.TransponderDataReady += Raise.EventWith(_fakeData);

            Assert.That(eventCalled, Is.EqualTo(1));
        }

    }
}
