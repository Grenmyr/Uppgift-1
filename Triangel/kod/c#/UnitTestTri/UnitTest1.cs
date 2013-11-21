﻿using System;
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
        public void isIsoscelesTest1()
        {
            // Test av Oliksidig Triangel
            Triangle tri1 = new Triangle(1, 3.5, 5);
            Assert.IsFalse(tri1.isIsosceles());
        }
         [TestMethod]
        // Test av metod för Likbent triangel
        public void isIsoscelesTest2()
         {
            Triangle tri2 = new Triangle(4.0, 4, 4.0);
            Assert.IsFalse(tri2.isIsosceles());
         }

         [TestMethod]
         // Test av metod för Likbent triangel
         public void isIsoscelesTest3()
         {
             Triangle tri3 = new Triangle(33.9, 30.5, 33.9);
             Assert.IsTrue(tri3.isIsosceles());
         }

        [TestMethod]
        // Test av metod för Liksidig Triangel
        public void isEquilateralTest1()
        {          
            Triangle tri1 = new Triangle(49, 50.5, 55);
            Assert.IsFalse(tri1.isEquilateral());
        }
        [TestMethod]
        // Test av metod för Liksidig Triangel
        public void isEquilateralTest2()
        {      
            Triangle tri2 = new Triangle(11, 011, 11.0);
            Assert.IsTrue(tri2.isEquilateral());
        }
          [TestMethod]
        // Test av metod för Liksidig Triangel
        public void isEquilateralTest3()
        {           
            Triangle tri3 = new Triangle(3, 4, 3.0);
            Assert.IsFalse(tri3.isEquilateral());
        }

        [TestMethod]
        // Test av metod för Oliksidig Triangel
        public void isScaleneTest1()
        {          
            Triangle tri1 = new Triangle(25, 20.5, 22.5);
            Assert.IsTrue(tri1.isScalene());
        }
        [TestMethod]
        // Test av metod för Oliksidig Triangel
        public void isScaleneTest2()
        {
            Triangle tri2 = new Triangle(101, 101.00, 101);
            Assert.IsFalse(tri2.isScalene());
        }
        [TestMethod]
        // Test av metod för Oliksidig Triangel
        public void isScaleneTest3()
        {
            Triangle tri3 = new Triangle(77, 77, 71.0);
            Assert.IsFalse(tri3.isScalene());
        }

        [TestMethod]
        // Test av Konstruktors BASFUNKTION med referens double som tilldelar fältet  "[] double sides" värde.
        public void TriangleOfTypeDoubleTest1()
        {
            // Tilldelar  3 double värden, fältet "sides" värde hämtas med hjälp av mats getfieldvalue metod som kopierats skamlöst.
            
            //Test 1: Testar att reclection fungerar och att konstruktorn kan tilldela fältet sides värde. 
            double[] sides = (double[])GetFieldValue(new Triangle(1, 1, 1), "sides");
            Assert.IsTrue(sides[0] == 1 && sides[1] == 1 && sides[2] == 1);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]       
        // Test av Konstruktors BASFUNKTION med referens double som tilldelar fältet  "[] double sides" värde.
        public void TriangleOfTypeDoubleTest2()
        {
            //Test 2: Testar att konstrutorn inte godkänner 0. Använder 0,1,1 eftersom jag vet att 1 tidigare fungerade. ******FAIL******            
            double[] sides2 = (double[])GetFieldValue(new Triangle(0, 1, 1), "sides");
            CollectionAssert.AreNotEqual(new double[] { 0, 1, 1 }, sides2);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        // Test av Konstruktors BASFUNKTION med referens double som tilldelar fältet  "[] double sides" värde.
        public void TriangleOfTypeDoubleTest3()
        {
            //Test 3: Testar att konstrutorn inte godkänner negativa värden (-9). ******FAIL******
            double[] sides3 = (double[])GetFieldValue(new Triangle(-9, 8, 8), "sides");
            CollectionAssert.AreNotEqual(new double[] { -9, 8, 8 }, sides3);
        }


        // Test av UNDANTAGSHANTERING Konstruktor med referens double som tilldelar fältet  "[] double sides" värde.
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
         public void ExceptionMessageTest1()
        {
            //Test 1 Matar in 4 double referenser i konstruktorn som hanterar referenser av typ DOUBLE ARRAY,  enkelt ändra till 2 element om så vill.
            double[] sides = new double[4];
            for (int i = 0; i <sides.Length; i++)
            {
                sides[i] = 1.3 * i;
            }

            Triangle tri = new Triangle(sides);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ExceptionMessageTest2()
        {
            // Test av konstruktor av typen point Array. Med 2 element bara. Förväntar mig undantag kastas.
            Point a = new Point(-8, 0);
            Point b = new Point(0, 5);

            double[] sides1 = (double[])GetFieldValue(new Triangle(new Point[] { a, b }), "sides");
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ExceptionMessageTest3()
        {
            // Test att undantag kastas då konstruktor initieras med negativa tal.

            double[] sides = (double[])GetFieldValue(new Triangle(new double[] { 5, -5, 4 }), "sides");
            
        }

        [TestMethod]
        // Test av Konstruktor med referens double [] som till konstruktorn.
        public void TriangleOfTypeDoubleArrayTest1()
        {         
            /* Tillelas min "fältet sides" en array med 3 element, som testas genom Getfieldvalue metoden som kopierats skamlöst!    
            Vi behöver ej testa andra värdetyper än Array av typen Double, Eftersom det är det enda som kommer godkännas som argument vid test 1. 
             Däremot måste vi testa Arrayens längd, eftersom kosntruktorn endast kör med .length metoden vid uppräkning av argument. */

            //Test 1:
            double[] sides = (double[])GetFieldValue(new Triangle(new double[] { 01, 2, 82.00 }), "sides");
            Assert.IsTrue(sides[0] == 1 && sides[1] == 2 && sides[2] == 82);         
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        // Test av Konstruktor med referens double [] som till konstruktorn.
        public void TriangleOfTypeDoubleArrayTest2()
        {
            //Test 2: Testar att kosntruktorn inte kan ta emot mindre än 3 Element av typen double.   ******FAIL******
            double[] sides2 = (double[])GetFieldValue(new Triangle(new double[] { 2, 2 }), "sides");
            Assert.IsFalse(sides2[0] == 2 && sides2[1] == 2);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        // Test av Konstruktor med referens double [] som till konstruktorn.
        public void TriangleOfTypeDoubleArrayTest3()
        {
            //Test 3: Testar att konstruktorn inte kan ta emot mer än 4 element av typen double.     ******FAIL******
            double[] sides3 = (double[])GetFieldValue(new Triangle(new double[] { 77, 77, 82, 99 }), "sides");
            Assert.IsFalse(sides3[0] == 77 && sides3[1] == 77 && sides3[2] == 82 && sides3[3] == 99);
        }
        [TestMethod]       
        // Test av Konstruktor med 3 referenser av typen Point.
        public void TriangleOfTypePointTest1()
        {
            // http://www.endmemo.com/geometry/triangle.php     
            // Väljer längden på sidorna till  5 och 8 då ska hypotenusan bli 9 (81)
            Point a = new Point(-8, 0);
            Point b = new Point(0, 5);
            Point c = new Point(0, 0);

            double[] sides = (double[])GetFieldValue(new Triangle(a, b, c), "sides");

            Assert.IsTrue(sides[0] == 8);
            Assert.IsTrue(sides[1] == Math.Sqrt(89));
            Assert.IsTrue(sides[2] == 5);
        }
        [TestMethod]  
        public void TriangleOfTypePointTest2()
        {
            // http://www.endmemo.com/geometry/triangle.php    
            // Väljer längden på sidorna till  5 och 8 då ska hypotenusan bli 9 (81)
            Point d = new Point(9, 0);
            Point e = new Point(9, 5);
            Point f = new Point(1, 0);

            double[] sides1 = (double[])GetFieldValue(new Triangle(d, e, f), "sides");
            Assert.IsTrue(sides1[0] == 8);
            Assert.IsTrue(sides1[1] == 5);
            Assert.IsTrue(sides1[2] == Math.Sqrt(89));
        }
        [TestMethod]  
        public void TriangleOfTypePointTest3()
        {
            // Testar initiera med helt annan triangeldata.
            Point g = new Point(2, 1);
            Point h = new Point(8, -1);
            Point i = new Point(4, 5);

            //Med Hjälp av http://www.endmemo.com/geometry/triangle.php vad värdenaa ska vara, så testresultat 3 ska bli sant om algoritmen stämmer.
            double[] sides2 = (double[])GetFieldValue(new Triangle(g, h, i), "sides");
            Assert.IsTrue(sides2[0] == Math.Sqrt(20));
            Assert.IsTrue(sides2[1] == Math.Sqrt(40));
            Assert.IsTrue(sides2[2] == Math.Sqrt(52));
        }

        [TestMethod]
        public void TriangleOfTypePointWithArrayTest1()
        {               
            // Test av triangel med 3 punkter som jag på förhand kollat vad resultatet ska bli genom använda.
            // http://www.endmemo.com/geometry/triangle.php
            Point a = new Point(-8, 0);
            Point b = new Point(0, 5);
            Point c = new Point(0, 0);

            double[] sides = (double[])GetFieldValue(new Triangle(new Point[] {a, b, c }), "sides");

            Assert.IsTrue(sides[0] == 8);
            Assert.IsTrue(sides[1] == Math.Sqrt(89));
            Assert.IsTrue(sides[2] == 5);
        }
        [TestMethod]
        public void TriangleOfTypePointWithArrayTest2()
        {

            // Test av samma storlek av triangel men med andra kordinater.
            Point d = new Point(9, 0);
            Point e = new Point(9, 5);
            Point f = new Point(1, 0);

            double[] sides1 = (double[])GetFieldValue(new Triangle(new Point[] { d, e, f }), "sides");
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
