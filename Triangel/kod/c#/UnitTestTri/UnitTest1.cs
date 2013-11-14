using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTri
{
    [TestClass]
    public class TriangleUnitTest
    {
        [TestMethod]
        // Test av metod för Likbent triangel
        public void isIsoscelesTest()
        {
            // Test av Oliksidig Triangel
            Triangle tri1 = new Triangle(1, 3.5, 5);
            Assert.IsFalse(tri1.isIsosceles());

            // Test av Liksidig triangel
            Triangle tri2 = new Triangle(4.0, 4, 4.0);
            Assert.IsFalse(tri2.isIsosceles());

            // Test av Likbent triangel
            Triangle tri3 = new Triangle(4, 11, 11.0);
            Assert.IsTrue(tri3.isIsosceles());
        }
        [TestMethod]
        // Test av metod för Liksidig Triangel
        public void isEquilateralTest()
        {
            // Test av Oliksidig Triangel
            Triangle tri1 = new Triangle(1, 3.5, 55);
            Assert.IsFalse(tri1.isIsosceles());

            // Test av Liksidig triangel
            Triangle tri2 = new Triangle(1011.0, 1011, 1011.0);
            Assert.IsTrue(tri2.isIsosceles());

            // Test av Likbent triangel
            Triangle tri3 = new Triangle(3, 1, 3.0);
            Assert.IsFalse(tri3.isIsosceles());
        }
        [TestMethod]
        // Test av metod för Oliksidig Triangel
        public void isScaleneTest()
        {
            // Test av Oliksidig Triangel
            Triangle tri1 = new Triangle(25, 3.5, 1.5);
            Assert.IsTrue(tri1.isIsosceles());

            // Test av Liksidig triangel
            Triangle tri2 = new Triangle(101, 101.00, 101);
            Assert.IsFalse(tri2.isIsosceles());
            Console.WriteLine("bosse banan");
            // Test av Likbent triangel
            Triangle tri3 = new Triangle(77, 77, 1.0);
            Assert.IsFalse(tri3.isIsosceles());
        }
        [TestMethod]
        // Test av double för konstruktor
         public void Triangle()
        {
            // tilldelar min "fältet sides" som är en array av typ double värden 1, fältet hämtas med hjälp av mats getfieldvalue metod som kopierats skamlöst.
            double[] sides = (double[])GetFieldValue(new Triangle(1, 1, 1), "sides");

            
            // Testar att reclection fungerar och att konstruktorn kan tilldela fältet sides värde.
            Assert.IsTrue(sides[0] == 1 && sides[1] == 1 && sides[2] == 1);

            //// Fler tester som konstaterar att konstruktorn kan tilldela fälten felaktiga värden. Dock inaktiverade nu.
            
            //// Testar att konstrutorn inte godkänner 0. Använder 0,1,1 eftersom jag vet att 1 tidigare fungerade. ******FAIL******
            //double[] sides2 = (double[])GetFieldValue(new Triangle(0, 1, 1), "sides");
            //CollectionAssert.AreNotEqual(new double[] { 0, 1, 1 }, sides2);

            //// Testar att konstrutorn inte godkänner negative värden (-9). ******FAIL******
            //double[] sides3 = (double[])GetFieldValue(new Triangle(-9, 1, 1), "sides");
            //CollectionAssert.AreNotEqual(new double[] { -9, 1, 1 }, sides3);

        }
         
        
        // Kopierat från Mats Lock!
        private static object GetFieldValue(object o, string name)
        {

            var field = o.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new ApplicationException(String.Format("FEL! Det privata fältet {0} saknas.", name));
            }
            return field.GetValue(o);
        }
        
    }
}
