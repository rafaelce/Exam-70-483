﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @" A rocket explorer called Wri
                ght, 
                Once travelled much faster than light, 
                He set out one day, 
                In a relative way, 
                And returned on the previous night";

            Console.WriteLine(text.LineCount()); Console.ReadKey();

        }
    }
}
