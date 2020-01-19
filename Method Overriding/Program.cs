using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Overriding
{
    class Program
    {
        class Document
        {
            public void GetDate()
            {
                Console.WriteLine("Hello from GetDate in Document");
            }

            //only methods that have been marked as 
            //virtual in the parent class can be overridden
            public virtual void DoPrint()
            {
                Console.WriteLine("Hello from DoPrint in Document");
            }

        }

        class Invoice : Document
        {
            public override void DoPrint()
            {
                Console.WriteLine("Hello from DoPrint in Invoice");
            }
        }

        class PrePaidInvoice : Invoice
        {
            public override void DoPrint()
            {
                base.DoPrint();
                Console.WriteLine("Hello from DoPrint in PrePaidInvoice");
            }
        }

        static void Main(string[] args)
        {
            Invoice c = new Invoice();
            c.GetDate();
            c.DoPrint();

            PrePaidInvoice p = new PrePaidInvoice();
            p.GetDate();
            p.DoPrint();

            Console.ReadKey();
        }
    }
}
