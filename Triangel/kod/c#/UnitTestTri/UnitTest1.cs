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
        // Test av Konstruktor med referens double som tilldelar fältet  "[] double sides" värde.
        public void TriangleOfTypeDoubleTest()
        {
            //tilldelar min "fältet sides" som är en array av typ double 3 double värden, fältet hämtas med hjälp av mats getfieldvalue metod som kopierats skamlöst.
            //Test 1: Testar att reclection fungerar och att konstruktorn kan tilldela fältet sides värde.
            double[] sides = (double[])GetFieldValue(new Triangle(1, 1, 1), "sides");
            Assert.IsTrue(sides[0] == 1 && sides[1] == 1 && sides[2] == 1);

            //Test 2: Testar att konstrutorn inte godkänner 0. Använder 0,1,1 eftersom jag vet att 1 tidigare fungerade. ******FAIL******            
            double[] sides2 = (double[])GetFieldValue(new Triangle(0, 1, 1), "sides");
            CollectionAssert.AreNotEqual(new double[] { 0, 1, 1 }, sides2);

            //Test 3: Testar att konstrutorn inte godkänner negativa värden (-9). ******FAIL******
            double[] sides3 = (double[])GetFieldValue(new Triangle(-9, 1, 1), "sides");
            CollectionAssert.AreNotEqual(new double[] { -9, 1, 1 }, sides3);
        }
        [TestMethod]
        // Test av Konstruktor med referens double [] som till konstruktorn.
        public void TriangleOfTypeDoubleArrayTest()
        {         
            /* Tillelas min "fältet sides" en array med 3 element, som testas genom Getfieldvalue metoden som kopierats skamlöst!    
            Vi behöver ej testa andra värdetyper än Array av typen Double, Eftersom det är det enda som kommer godkännas som argument vid test 1. 
             Däremot måste vi testa Arrayens längd, eftersom kosntruktorn endast kör med .length metoden vid uppräkning av argument. */

            //Test 1:
            double[] sides = (double[])GetFieldValue(new Triangle(new double[] { 01, 2, 82.00 }), "sides");
            Assert.IsTrue(sides[0] == 1 && sides[1] == 2 && sides[2] == 82);
            
            //Test 2: Testar att kosntruktorn inte kan ta emot mindre än 3 Element av typen double.   ******FAIL******
            double[] sides2 = (double[])GetFieldValue(new Triangle(new double[] { 1, 2 }), "sides");
            Assert.IsFalse(sides2[0] == 1 && sides2[1] == 2);

            //Test 3: Testar att konstruktorn inte kan ta emot mer än 4 element av typen double.     ******FAIL******
            double[] sides3 = (double[])GetFieldValue(new Triangle(new double[] { 1, 2, 82, 1 }), "sides");
            Assert.IsFalse(sides3[0] == 1 && sides3[1] == 2 && sides3[2] == 82 && sides3[3] == 1);                    
        }
        [TestMethod]
        // Test av Konstruktor med 3 referenser av typen Point.
        public void TriangleOfTypePointTest()
        {
            // Dunkade in matte som Sharief fixat.           
            // Väljer längden på sidorna till  5 och 8 då ska hypotenusan bli 9 (81)
            Point a = new Point(-8,0);
            Point b = new Point(0,5);
            Point c = new Point(0,0);

            double[] sides = (double[])GetFieldValue(new Triangle(a, b, c), "sides");

            Assert.IsTrue(sides[0] == 8);
            Assert.IsTrue(sides[1] == Math.Sqrt(89));
            Assert.IsTrue(sides[2] == 5);

            // Testar igen med samma längder på sidorna men annan följdordning på element.
            Point d = new Point(8, 0);
            Point e = new Point(8, 5);
            Point f = new Point(0, 0);

            double[] sides1 = (double[])GetFieldValue(new Triangle(d, e, f), "sides");
            Assert.IsTrue(sides1[0] == 8);
            Assert.IsTrue(sides1[1] == 5);
            Assert.IsTrue(sides1[2] == Math.Sqrt(89));
            
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
