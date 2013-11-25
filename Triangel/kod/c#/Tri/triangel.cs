using System;
using System.Linq;
using System.Collections.Generic;

public struct Point { 
  public int x, y;
  
  public Point(int a, int b) {
    x = a;
    y = b;
  }
}

public class Triangle {
     double[] sides;

      // egenskap
      public double[] MyProp
      {
          get
          {
              return sides;
          }
          set
          {
             
              if (value.Length != 3  )
              {
                  throw new ArgumentException("Triangeln har inte 3 sidor");
              }
              foreach (double element in value)
              {
                    if (element <= 0 )
                    {
                        throw new ArgumentException("Feaktigt inmatat värde");
                    }
                    if (element > Math.Pow(2, 32))
                    {
                        throw new ArgumentException("För stor sida inmatad.");
                    }
              }
              sides = value;
          }
    }
    public Triangle()
    {
        // Empty
    }

    public Triangle(double a, double b, double c)
    {
        MyProp = new double[] { a, b, c };
    } 

    public Triangle(double[] s) 
    {       
        MyProp = s;
    } 

    public Triangle(Point a, Point b, Point c)
    {     
        // Lägger in punkterna i en array som skickas till en privat metod för beräkning av triangelns sidor. Triangelns sidor returneras i en array
        // som sedan tilldelas egenskapen myProp för validering innan sidorna slutligen initieras till fältet sides.
        MyProp = myMethod(new Point [] {a,b,c});
    }

    public Triangle(Point[] s) 
    {
        if (s.Length != 3)
        {
            throw new ArgumentException("arrayens längd är ej 3");
        }
        MyProp = myMethod(s);
    }
    private double[] myMethod(Point [] array)
    {
        // Metod, kör uträkning för point Trianglar.
        sides = new double[3];
        sides[0] = Math.Sqrt(Math.Pow((double)(array[2].x - array[0].x), 2.0) + Math.Pow((double)(array[2].y - array[0].y), 2.0));
        sides[1] = Math.Sqrt(Math.Pow((double)(array[1].x - array[0].x), 2.0) + Math.Pow((double)(array[1].y - array[0].y), 2.0));
        sides[2] = Math.Sqrt(Math.Pow((double)(array[2].x - array[1].x), 2.0) + Math.Pow((double)(array[2].y - array[1].y), 2.0));
        return sides;
    }

    private int uniqueSides() 
        {
            return sides.Distinct<double>().Count();
        }
    // Oliksidig
    public bool isScalene() 
        {
            if (uniqueSides() == 3)
            {
                return true;
            }            
            return false;
        }
    //liksidig
    public bool isEquilateral() 
        {
        if (uniqueSides() == 1)
            {
                return true;
            }    
            return false;
        }
    //likbent
    public bool isIsosceles() 
    {
        if (uniqueSides() == 2) 
        {
            return true;
        }     
        return false;
    }
}

