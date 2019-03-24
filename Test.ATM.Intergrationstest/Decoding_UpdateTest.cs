using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;


namespace Test.ATM.Intergrationstest
{
    public class Decoding_UpdateTest
    {
        private ITransponderReceiver _receiver;
        private List<IUpdate> _ftracks;

        private RawTransponderDataEventArgs _faketracks;
        private Decoding decoding;
        private List<string> list;

        [SetUp]
        public void SetUp()
        {
            list = new List<string>();
            _receiver = Substitute.For<ITransponderReceiver>();
            _ftracks = new List<IUpdate>();
            decoding = new Decoding(_receiver);
            list.Add("Test1;111;222;333;20190325120032121");
            _faketracks = new RawTransponderDataEventArgs(list);

            _receiver.TransponderDataReady += Raise.EventWith(_faketracks);
        }

        [Test]
        public void Update_Created_Tag()
        {
            Assert.That(decoding._ftracks[0]._tag, Is.EqualTo("Test1"));
        }

        [Test]
        public void Update_Created_X_Cor()
        {
            Assert.That(decoding._ftracks[0]._xcoordinate, Is.EqualTo(111));
        }

        [Test]
        public void Update_Created_Y_Cor()
        {
            Assert.That(decoding._ftracks[0]._ycoordinate, Is.EqualTo(222));
        }

        [Test]
        public void Update_Created_Date()
        {
            DateTime datetime1 = DateTime.ParseExact("20190325120032121", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            Assert.That(decoding._ftracks[0]._date, Is.EqualTo(datetime1));
        }
    }
}
