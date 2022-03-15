using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crashCourse.Shapes
{
    public class Rectangle
    {
        public void Calc(float a,float b)
        {
            Console.WriteLine("The surface of the rectangle is {0:F2}", a * b);
            Console.WriteLine("The perimeter of the rectangle is {0:F2}", 2*(a+b));
            Console.WriteLine("The diagonal of the rectangle is {0:F2}", Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)));
        }
    }
}
