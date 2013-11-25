using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTriangel
{
    [TestClass]
    public class Test
    {
        //liksidig (Equilateral), 
        //likbent (Isosceles)
        //inte några lika sidor (Scalene)

        [TestMethod]
        public void isIsoscelesTest()
        {
            Triangle t = new Triangle(1.0, 0.5, 1.0);
            Assert.IsTrue(t.isIsosceles());
        }
        public void isEquilateralTest() { }
        public void isScaleneTest() { }

        [TestMethod]
        public void TestConstrunctorDoubleValue()
        {
            //Tre double argument giltiga värden
            double[] sides = (double[])GetFieldValue(new Triangle(3, 4, 5), "sides");

            //testar om fältet i konstruktorn tar hand om samma värden som skickats med. 
            Assert.IsTrue(sides[0] == 3 && sides[1] == 4 && sides[2] == 5, "Programmet tar inte hand om data på ett korrekt sätt");
        }
        [TestMethod]
        public void TestConstructorArrayValue()
        {
            //Skapar ett objekt med en double Array som argument
            double[] sides = (double[])GetFieldValue(new Triangle(new double[] { 3, 4, 5 }), "sides");
            Assert.IsTrue(sides[0] == 3 && sides[1] == 4 && sides[2] == 5);
        }

        //[TestMethod]
        //public void GetArrayValue()
        //{
        //    double[] sides = (double[])GetFieldValue(new Triangle(new double[] { 3, 4, 5 }), "sides");
        //    Assert.IsTrue(sides[0] == 3 && sides[1] == 4 && sides[2] == 5);

        //}
        //Testar konstuktor som tar 3 punkter som argument
        [TestMethod]
        public void TestConstructorPointValue()
        {
            Point p1 = new Point(4, 0);
            Point p2 = new Point(0, 3);
            Point p3 = new Point(0, 0);

            double[] sides = (double[])GetFieldValue(new Triangle(p1, p2, p3), "sides");

            //Kontrollera att programmet räknar ut rätt längd på sidorna
            Assert.IsTrue(sides[0] == 4, "programmet räknar inte ut sidorna rätt!!");
            Assert.IsTrue(sides[1] == Math.Sqrt(25), "programmet räknar inte ut sidorna rätt!!");
            Assert.IsTrue(sides[2] == 3, "programmet räknar inte ut sidorna rätt!!");
        }

        //Testar konstuktor som tar en Array med punkter 
        [TestMethod]
        public void TestConstructorArrayPointValue()
        {
            Point p1 = new Point(5, 0);
            Point p2 = new Point(0, 8);
            Point p3 = new Point(0, 0);

            double[] sides = (double[])GetFieldValue(new Triangle(new Point[] { p1, p2, p3 }), "sides");


            //Kontrollera att programmet räknar ut rätt längd på sidorna
            Assert.IsTrue(sides[0] == 4);
            Assert.IsTrue(sides[1] == Math.Sqrt(100));
            Assert.IsTrue(sides[2] == 3);
        }

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
