#define TERSE
//#define VERBOSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._5_Reflection
{
    class Program
    {
        [Conditional("VERBOSE"), Conditional("TERSE")]
        static void reportHeader()
        {
            Console.WriteLine("This is the header for the report.");
        }

        [Conditional("VERBOSE")]
        static void verboseReport()
        {
            Console.WriteLine("This is output from the verbose report.");
        }

        [Conditional("TERSE")]
        static void terseReport()
        {
            Console.WriteLine("This is output from the terse report.");
        }

        class Pessoa
        {
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            reportHeader();
            terseReport();
            verboseReport();

            System.Type type;

            Pessoa p = new Pessoa();
            type = p.GetType();

            foreach (MemberInfo member in type.GetMembers())
            {
                Console.WriteLine($"{member.ToString()} \n");
            }

            MethodInfo setMethod = type.GetMethod("set_Name");
            setMethod.Invoke(p, new object[] { "Fred" });

            Console.WriteLine($"Name: {p.Name}");

            Console.ReadKey();
        }
    }
}
