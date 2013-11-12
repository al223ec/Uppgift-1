using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTriangel
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void isIsoscelesTest()
        {
            Triangle t = new Triangle(1.0,0.5,1.0); 
            Assert.IsTrue(t.isIsosceles());
        }

        public void isEquilateralTest()
        {

        }

        public void isScaleneTest()
        {

        }

    }
}
