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
            Triangle tri2 = new Triangle(3.0, 3.0, 3.0);
            Assert.IsFalse(tri2.isIsosceles());

            // Test av Likbent triangel
            Triangle tri3 = new Triangle(3, 1, 3.0);
            Assert.IsTrue(tri3.isIsosceles());
        }
    }
}
