using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._26_COM_interopt
{
    class Program
    {
        class Customer {
            public string Nome;
            private string _nameValue;

            public string PrivateName {
                get {
                    return _nameValue;
                }
                set {
                    if (value == "")
                        throw new Exception("Invalid customer name.");
                    _nameValue = value;
                }
            }
        }

        static void Main(string[] args)
        {
            // Create the interop 
            //var excelApp = new Microsoft.Office.Interop.Excel.Application();

            // make the app visible 
            //excelApp.Visible = true;

            // Add a new workbook 
            //excelApp.Workbooks.Add();

            // Obtain the active sheet from the app 
            // There is no need to cast this dynamic type 
            //Microsoft.Office.Interop.Excel.Worksheet workSheet = excelApp.ActiveSheet;

            // Write into two cells 
            //workSheet.Cells[ 1, "A"] = "Hello";
            //workSheet.Cells[ 1, "B"] = "from C#";

            Customer c = new Customer();
            c.Nome = "Rafael";

            Console.WriteLine($"Customer name: {c.Nome}");

            c.PrivateName = "Rafael Cruz";
            Console.WriteLine($"Customer name: {c.PrivateName}");

            Console.ReadKey();
        }
    }
}
