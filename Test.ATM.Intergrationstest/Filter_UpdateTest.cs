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
    class Filter_UpdateTest
    {
        private IDecoding decoding_;
        private Update updatetrack;
        private Update updatetrack2;
        private Filter filter_;
        private Track track_;
        private Decoding.UpdateEvent updateEvent;

        [SetUp]
        public void SetUp()
        {

            DateTime dt1 = DateTime.ParseExact("20190325", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact("20190325", "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);

            updatetrack = new Update("YYY", 20000, 20000, 500, dt1);
            updatetrack2 = new Update("YYY", 20000, 20050, 500, dt2);


            decoding_ = Substitute.For<IDecoding>();
            filter_ = new Filter(decoding_);

            List<IUpdate> updatekList = new List<IUpdate>() { updatetrack, updatetrack2 };
            updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = updatekList;

            decoding_._updateCreated += Raise.EventWith(updateEvent);

        }

        [Test]
        public void TrackCreated_ContainingCorrectTag()
        {
            Assert.That(filter_.updateDic.Equals(updatetrack._tag));
        }
    }
}
