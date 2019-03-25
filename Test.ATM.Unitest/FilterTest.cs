using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using ATMClasses.Interface;
using NSubstitute;
using NUnit.Framework;

namespace Test.ATM.Unitest
{
    public class FilterTest
    {
        private IDecoding _decoding;
        private Filter _uut;
        private Update _fakeUpdate;
        private int _eventCalled;
        private IUpdate _utrack1;
        private IUpdate _utrack2;
        private IUpdate _utrack3;
        private IUpdate _utrack4;

        [SetUp]

        public void SetUp()
        {
            _decoding = Substitute.For<IUpdate>();
            _utrack1._tag = "Ahmed";
            _utrack1._xcoordinate = 8000.25;
            _utrack1._ycoordinate = 9000.25;
            _utrack1._altitude = 500.25;
            _utrack1._date = DateTime.Now;
            _utrack1.InAirspace = false;

            _decoding = Substitute.For<IUpdate>();
            _utrack2._tag = "Ellen";
            _utrack2._xcoordinate = 8500.25;
            _utrack2._ycoordinate = 9500.25;
            _utrack2._altitude = 500.25;
            _utrack2._date = DateTime.Now;
            _utrack2.InAirspace = false;

            _decoding = Substitute.For<IUpdate>();
            _utrack3._tag = "Sug";
            _utrack3._xcoordinate = 1000.25;
            _utrack3._ycoordinate = 11000.25;
            _utrack3._altitude = 500.25;
            _utrack3._date = DateTime.Now;
            _utrack3.InAirspace = true;

            _decoding = Substitute.For<IUpdate>();
            _utrack4._tag = "ST4";
            _utrack4._xcoordinate = 12000.25;
            _utrack4._ycoordinate = 13000.25;
            _utrack4._altitude = 500.25;
            _utrack4._date = DateTime.Now;
            _utrack4.InAirspace = true;

            _eventCalled = 0;

            _uut.TrackEdited += (0, args) =>
            {
                ++_eventCalled;
            }


        }
    

    }
}
