using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTri
{
    [TestClass]
    public class TriangleUnitTest
    {
        [TestMethod]
        public void isIsoscelesTest()
        {
            Triangle tri = new Triangle(1, -3.5, 5);
            Assert.IsTrue(tri.isIsosceles());
        }
    }
}
