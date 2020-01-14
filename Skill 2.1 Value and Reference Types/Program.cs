using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._1_Value_and_Reference_Types
{
    class Program
    {
        struct StructStore { public int Data { get; set; } }
        class ClassStore { public int Data { get; set; } }

        /// <summary>
        /// Example of struct
        /// </summary>
        struct Alien {
            public int X;
            public int Y;
            public int Lives;

            public Alien(int x, int y) {
                X = x;
                Y = y;
                Lives = 3;
            }

            public override string ToString()
            {
                return string.Format($"x: {X} Y: {Y} Lives {Lives}");
            }
        }

        /// <summary>
        /// Example of enum
        /// </summary>
        enum AlienState {
            Sleeping,
            Attacking,
            Destroyed
        };

        /// <summary>
        /// Example of enum with definer values.
        /// </summary>
        enum AlienStateTwo : byte
        {
            Sleeping = 1,
            Attacking = 2,
            Destroyed = 4
        };

        static void Main(string[] args)
        {
            StructStore xs, ys; ys = new StructStore();
            ys.Data = 99;
            xs = ys;
            xs.Data = 100;

            Console.WriteLine(" xStruct: {0}", xs.Data);
            Console.WriteLine(" yStruct: {0}", ys.Data);

            ClassStore xc, yc;
            yc = new ClassStore();
            yc.Data = 99;

            xc = yc;
            xc.Data = 100;

            Console.WriteLine(" xClass: {0}", xc.Data);
            Console.WriteLine(" yClass: {0}", yc.Data);

            Alien a;
            a.X = 50;
            a.Y = 50;
            a.Lives = 3;
            Console.WriteLine($" a {yc.Data}");

            Alien x = new Alien(100,100);
            Console.WriteLine($" x {yc.Data}");

            Alien[] swarm = new Alien[100];
            Console.WriteLine($" swarm [0] {swarm[0].ToString()}");

            AlienState alienstate = AlienState.Attacking;
            Console.WriteLine($" enum AlienState {alienstate}");

            AlienStateTwo alienstatetwo = AlienStateTwo.Attacking;
            Console.WriteLine($" enum AlienStateTwo {alienstatetwo}");

            Console.ReadKey();
            
        }

        /// <summary>
        /// Example of class
        /// </summary>
        class AlienClass {
            public int X;
            public int Y;
            public int Lives;

            public AlienClass(int x, int y)
            {
                X = x;
                Y = y;
                Lives = 3;
            }

            public override string ToString()
            {
                return string.Format($"x: {X} Y: {Y} Lives {Lives}");
            }
        }
    }
}
