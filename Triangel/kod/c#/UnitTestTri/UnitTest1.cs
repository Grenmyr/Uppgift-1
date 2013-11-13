using System;
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
            Triangle tri1 = new Triangle(1, 3.5 , 5);
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
            Triangle tri2 = new Triangle(4.0, 4, 4.0);
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

            // Test av Likbent triangel
            Triangle tri3 = new Triangle(77, 77, 1.0);
            Assert.IsFalse(tri3.isIsosceles());
        }
        public void uniqueSidesTest()
        {
           
        }
    }
}
