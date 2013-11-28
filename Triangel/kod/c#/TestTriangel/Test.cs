using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

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
        
        [TestMethod]
        public void isEquilateralTest() 
        {
            Triangle t = new Triangle(6, 6, 6);
            Assert.IsTrue(t.isEquilateral());
        }
        
        [TestMethod]
        public void isScaleneTest() 
        {
            Triangle t = new Triangle(2.0, 3, 3.61);
            Assert.IsTrue(t.isScalene());
        }
        [TestMethod]
        public void isNotIsoscelesTest()
        {
            Triangle t = new Triangle(2.0, 3.0, 3.61);
            Assert.IsFalse(t.isIsosceles());
        }

        [TestMethod]
        public void isNotEquilateralTest()
        {
            Triangle t = new Triangle(6, 3, 6);
            Assert.IsFalse(t.isEquilateral());
        }

        [TestMethod]
        public void isNotScaleneTest()
        {
            Triangle t = new Triangle(3, 3, 3);
            Assert.IsFalse(t.isScalene());
        }

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
            Assert.IsTrue(sides[0] == 3 && sides[1] == 4 && sides[2] == 5, "Programmet tar inte hand om double arrayen på ett korrekt sätt");
        }
        [TestMethod]
        public void TestConstructorPointValue()
        {
            Point a = new Point(4, 0);
            Point b = new Point(0, 3);
            Point c = new Point(0, 0);

            double[] sides = (double[])GetFieldValue(new Triangle(a, b, c), "sides");

            Assert.IsTrue(sides[0] == 5, "programmet räknar inte ut sidan 0 rätt!!"); //c 
            Assert.IsTrue(sides[1] == 4, "programmet räknar inte ut sidan 1 rätt!!"); //b
            Assert.IsTrue(sides[2] == 3, "programmet räknar inte ut sidan 2 rätt!!"); //a
        }

        //Testar konstuktor som tar en Array med punkter 
        [TestMethod]
        public void TestConstructorArrayPointValue()
        {
            Point a = new Point(4, 0);
            Point b = new Point(0, 3);
            Point c = new Point(0, 0);

            double[] sides = (double[])GetFieldValue(new Triangle(new Point[]{ a, b, c }), "sides");

            //Kontrollera att programmet räknar ut rätt längd på sidorna
            Assert.IsTrue(sides[0] == 5, "programmet räknar inte ut sidan 0 rätt!!"); //c 
            Assert.IsTrue(sides[1] == 4, "programmet räknar inte ut sidan 1 rätt!!"); //b
            Assert.IsTrue(sides[2] == 3, "programmet räknar inte ut sidan 2 rätt!!"); //a
        }

        [TestMethod]
        public void TestConstructorFaultyPointValues()
        {
            Point a = new Point(4, 0);
            Point b = new Point(0, 3);
            Point c = new Point(0, 0);
            Point d = new Point(4, 0);
            Point e = new Point(0, 3);
            Point f = new Point(0, 0);

            try
            {
                Triangle trianglePoints = new Triangle(new Point[] { a, b, c, d, e, f });
                throw new ApplicationException();
            }
            catch (ArgumentException)
            {
                return;
            }
            catch
            {
                Assert.Fail("ArgumentException kastas inte när ett triangel objekt intieras med felaktigt antal point värden");
            }
        }
        [TestMethod]
        public void TestConstructorFaultyDoubleValues()
        {
            try
            {
                Triangle triangleDouble = new Triangle(-3, -98, 0);
                throw new ApplicationException();
            }
            catch (ArgumentException)
            {
                return;
            }
            catch
            {
                Assert.Fail("ArgumentException kastas inte när ett triangel objekt intieras med felaktiga double värden");
            }
        }
        [TestMethod]
        public void TestConstructorFaultyDoubleArrayValues()
        {
            try
            {
                Triangle triangleDoubleArray = new Triangle(new double[]{ 3, 4, 5, 6, 7 });
                throw new ApplicationException();
            }
            catch (ArgumentException)
            {
                return;
            }
            catch
            {
                Assert.Fail("ArgumentException kastas inte när ett triangel objekt intieras med en för stor double array värden");
            }
        }

        [TestMethod]
        public void TestPoint()
        {
            Point a = new Point(4, 0);

            Assert.IsTrue(a.x == 4, "point structuren tilldelar inte värden rätt!!");
            Assert.IsTrue(a.y == 0, "point structuren tilldelar inte värden rätt!!");
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
