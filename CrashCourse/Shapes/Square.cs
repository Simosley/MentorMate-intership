using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crashCourse.Shapes
{
    public class Square
    {
        public void Calc(float a)
        {
            Console.WriteLine("The surface of the square is {0:F2}", a * a);
            Console.WriteLine("The perimeter of the sqaure is {0:F2}", a * 4);
            Console.WriteLine("The diagonal of the sqaure is {0:F2}",(a*Math.Sqrt(2)));
            

        }
    }
}
