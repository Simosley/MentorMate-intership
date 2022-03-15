using System;
using crashCourse.Shapes;



namespace crashCourse
{
   
    class MainClass
    {
        static void Main(string[] args)
        {
            var loop = true;
            while (loop)
            {
                Console.WriteLine("");
                Console.WriteLine("                         What shape would you like to find the area ,the surface and the diagonal?");
                Console.WriteLine("Choose your shape");
                Console.WriteLine("------------------");
                Console.WriteLine("1. Square");
                Console.WriteLine("2. Triangle");
                Console.WriteLine("3. Rectangle");
                Console.WriteLine("0. Exit");
                

                int x = int.Parse(Console.ReadLine());

                if (x == 1)
                {
                    Console.WriteLine("You have chosen Square.");
                    Console.Write("Please enter the side of the square: ");
                    float a = float.Parse(Console.ReadLine());
                    var square = new Square();
                    square.Calc(a);
                }
                else if (x == 2)
                {
                    Console.WriteLine("You have chosen Triangle.");
                    Console.Write("Please enter the a: ");
                    float a = float.Parse(Console.ReadLine());
                    Console.Write("Please enter the b: ");
                    float b = float.Parse(Console.ReadLine());
                    Console.Write("Please enter the c: ");
                    float c = float.Parse(Console.ReadLine());
                    Console.Write("Please enter the h: ");
                    float h = float.Parse(Console.ReadLine());
                    var triangle = new Triangle();
                    triangle.Calc(a, b, c, h);

                }
                else if (x == 3)
                {
                    Console.WriteLine("You have chosen Rectangle.");
                    Console.Write("Please enter the height of the Rectangle: ");
                    float a = float.Parse(Console.ReadLine());
                    Console.Write("Please enter the width of the Rectangle: ");
                    float b = float.Parse(Console.ReadLine());
                    var rectangle = new Rectangle();
                    rectangle.Calc(a, b);
                }
                else if(x == 0)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }


                
            }

        }

    }
}