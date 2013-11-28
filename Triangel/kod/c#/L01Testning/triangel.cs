using System;
using System.Linq;
using System.Collections.Generic;

public struct Point
{
    public int x, y;

    public Point(int a, int b)
    {
        x = a;
        y = b;
    }
}

public class Triangle
{
    private double[] sides;

    private double[] Sides
    {
        set
        {
            if (value.Length > 3)
            {
                throw new ArgumentException("En triangel kan endast ha 3 sidor");
            }
            foreach (double side in value)
            {
                if (side < 0)
                {
                    throw new ArgumentException("Detta är ett ogiltigt värde för en triangel");
                }
            }
            if (!((value[0] + value[1]) > value[2] && (value[0] + value[2]) > value[1] && (value[1] + value[2]) > value[1]))
            {
                throw new ArgumentException("Dessa tre värden kan inte forma en triangel");
            }
            sides = value;
        }
    }

    public Triangle(double a, double b, double c)
    {
        Sides = new double[] { a, b, c };
    }

    public Triangle(double[] s)
    {
        Sides = s;
    }

    public Triangle(Point a, Point b, Point c)
    {
        Sides = new double[3]{
        Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0)),
        Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0)),
        Math.Sqrt(Math.Pow((double)(c.x - b.x), 2.0) + Math.Pow((double)(c.y - b.y), 2.0))
      };
        //sides[0] = Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0));
        //sides[1] = Math.Sqrt(Math.Pow((double)(b.x - c.x), 2.0) + Math.Pow((double)(b.x - a.x), 2.0));
        //sides[2] = Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.x - a.x), 2.0));
    }

    public Triangle(Point[] s)
    {
        if (s.Length > 3)
        {
            throw new ArgumentException("En triangel kan endast ha 3 sidor");
        }
        Sides = new double[]{
        Math.Sqrt(Math.Pow((double)(s[1].x - s[0].x), 2.0) + Math.Pow((double)(s[1].y - s[0].y), 2.0)),
        Math.Sqrt(Math.Pow((double)(s[2].x - s[0].x), 2.0) + Math.Pow((double)(s[2].y - s[0].y), 2.0)),
        Math.Sqrt(Math.Pow((double)(s[2].x - s[1].x), 2.0) + Math.Pow((double)(s[2].y - s[1].y), 2.0))
      };
        //sides[0] = Math.Sqrt(Math.Pow((double)(s[1].x - s[0].x), 2.0) + Math.Pow((double)(s[1].y - s[0].y), 2.0));
        //sides[1] = Math.Sqrt(Math.Pow((double)(s[1].x - s[2].x), 2.0) + Math.Pow((double)(s[1].x - s[2].x), 2.0));
        //sides[2] = Math.Sqrt(Math.Pow((double)(s[2].x - s[0].x), 2.0) + Math.Pow((double)(s[2].x - s[0].x), 2.0));
    }

    //Denna metod returnerar hur många unika sidor triangeln har, 1 unik sida == alla sidor är lika
    private int uniqueSides()
    {
        return sides.Distinct<double>().Count();
    }

    public bool isScalene()
    {
        if (uniqueSides() == 3)
            return true;
        return false;
    }

    public bool isEquilateral()
    {
        if (uniqueSides() == 1)
            return true;
        return false;
    }

    public bool isIsosceles()
    {
        if (uniqueSides() == 2)
            return true;
        return false;
    }
}
class Program
{
    static void Main(string[] args) { }
}

//Exempel på användning: 
// class Program { 
//static void Main(string[] args) { 
//double[] input = new double[3]; 
//for(int i=0;i<3;i++) 
//input[i]=double.Parse(args[i]);

//Triangle t = new Triangle(input);

//if(t.isScalene()) Console.WriteLine("Triangeln har inga lika sidor"); 
//if(t.isEquilateral()) Console.WriteLine("Triangeln är liksidig");
//if(t.isIsosceles()) Console.WriteLine("Triangeln är likbent");
//}
//}
