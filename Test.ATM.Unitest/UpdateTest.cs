using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using NUnit.Framework;


namespace Test.ATM.Unitest
{
    public class UpdateTest
    {
        [TestCase(10000, 100000, 500)]
        [TestCase(90000, 90000, 20000)]
        

        //Metoden, scenario og det forvenetet resultat:
        public void BoundaryCoordinates_Returns_InAirspaceTrue(double X, double Y, double altitude)
        {
           
          
             Update test= new Update("XXX", X, Y, altitude, DateTime.Now);

            Assert.That(test.InAirspace.Equals(true));
        }

        [TestCase(9999, 10000, 500)]
        [TestCase(10000, 9999, 500)]
        [TestCase(10000, 10000, 499)]
        [TestCase(90001, 90000, 20000)]
        [TestCase(90000, 90001, 20000)]
        [TestCase(90000, 90000, 20001)]

        //Metoden, scenario og det forvenetet resultat:
        public void BoundaryCoordinates_Returns_InAirspaceFalse(double X, double Y, double altitude)
        {
            Update test = new Update("XXX", X, Y, altitude, DateTime.Now);

            Assert.That(test.InAirspace.Equals(false));
        }

    }
}
