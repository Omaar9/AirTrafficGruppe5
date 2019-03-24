using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using NUnit.Framework;
using NSubstitute;

namespace Test.ATM.Intergrationstest
{
    public class Filter_TrackTest
    {
        private IDecoding decoding_;
        private Filter filter_;
        private Decoding.UpdateEvent updateEvent;
        private IUpdate updatetrack;
        private IUpdate updatetrack2;

        [SetUp]
        public void SetUp()
        {

            DateTime dt1 = DateTime.ParseExact("20190325", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact("20190325", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);

            updatetrack = Substitute.For<IUpdate>();
            updatetrack._tag = "YYY";
            updatetrack._xcoordinate = 20000;
            updatetrack._ycoordinate = 20000;
            updatetrack._altitude = 500;
            updatetrack._date = dt1;

            updatetrack2 = Substitute.For<IUpdate>();
            updatetrack2._tag = "YYY";
            updatetrack2._xcoordinate = 20050;
            updatetrack2._ycoordinate = 20000;
            updatetrack2._altitude = 500;
            updatetrack2._date = dt2;

            decoding_ = Substitute.For<IDecoding>();
            filter_ = new Filter(decoding_);

           

            List<IUpdate> updatekList = new List<IUpdate>() { updatetrack, updatetrack2 };

            updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = updatekList;

            decoding_._updateCreated += Raise.EventWith(updateEvent);

           

        }

        [Test]
        public void TrackCreated()
        {
           
            Assert.That(filter_._dictionaryUpdate.Equals(updatetrack._tag));
        }
    }
}
