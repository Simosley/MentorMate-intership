using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crashCourse.Shapes
{
    public class Triangle
    {
        public void Calc(float a,float b ,float c,float h)
        {
            Console.WriteLine("The surface of the triangle is {0:F2}", ((b * h)/2));
            Console.WriteLine("The perimeter of the triangle is {0:F2}", a +b+c);
            Console.WriteLine("The hypotenuse of the triangle is {0:F2}", Math.Sqrt(Math.Pow(a,2)+Math.Pow(b,2)));
        }
    }
}
