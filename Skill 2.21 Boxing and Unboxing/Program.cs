using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._21_Boxing_and_Unboxing
{
    class Program
    {
        class Miles
        {
            public Double Distance { get; }

            public static implicit operator Kilometers(Miles t)
            {
                Console.WriteLine("Implicite conversion from miles to kilometers");
                return new Kilometers(t.Distance * 1.6);
            }

            public static explicit operator int(Miles t)
            {
                Console.WriteLine("Implicite conversion from miles to int");
                return (int)(t.Distance + 0.5);
            }

            public Miles(double miles)
            {
                Distance = miles;
            }
        }

        class Kilometers
        {
            public Double Distance { get; }

            public Kilometers(double kilimeters)
            {
                Distance = kilimeters;
            }
        }

        static void Main(string[] args)
        {
            // thw value 99 is boxed into a object
            object o = 99;

            // the boxed object is unboxed back into an int
            int oVal = (int)o;
            Console.WriteLine($"The value is {oVal} \n\n");


            Miles m = new Miles(100);

            Kilometers k = m; //implicity convert miles to km.
            Console.WriteLine($"Kilometers: {k.Distance} ");

            int intMiles = (int)m; // explicity convert miles to int.
            Console.WriteLine($"Int miles: {intMiles} \n\n");

            MessageDisplay md = new MessageDisplay();
            md.DisplayMessage("Hello World!");

            dynamic d = new MessageDisplay();
            //d.Banana("Hello World!");

            Console.ReadKey();
        }

        class MessageDisplay {

            public void DisplayMessage(string message)
            {
                Console.WriteLine(message);
            }
        }

        
    }
}
