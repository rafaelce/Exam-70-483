using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._4_Create_and_Implement_a_Class_Hierarchy
{
    class Program
    {
        interface IPrintable
        {
            string GetPrintableText(int pageWidth, int pageHeight);
            string GetTitle();
        }

        class Report : IPrintable
        {
            public string GetPrintableText(int pageWidth, int pageHeight)
            {
                return "Report Text";
            }

            public string GetTitle()
            {
                return "Report Title";
            }
        }
        static void Main(string[] args)
        {
        }


    }
}
