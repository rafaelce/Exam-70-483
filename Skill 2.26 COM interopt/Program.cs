using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._26_COM_interopt
{
    class Program
    {
        class Customer
        {
            public string Nome;
            private string _nameValue;

            /*
                Note that there is a C# convention  that private members of a class have identifiers
                thet start with an underscore (_) character.
            */

            public string PrivateName
            {
                get
                {
                    return _nameValue;
                }
                set
                {
                    if (value == "") { throw new Exception("Invalid customer name."); }
                    _nameValue = value;
                }
            }
        }

        class BankAccount
        {
            protected class Address
            {
                public string FirstLine;
                public string Postcode;
            }

            private decimal _accountBalance = 0;

            public void PayInFunds(decimal amountPayIn)
            {
                _accountBalance = _accountBalance + amountPayIn;
            }

            public bool WithdrawFunds(decimal amountToWithdraw)
            {
                if (amountToWithdraw > _accountBalance)
                    return false;

                _accountBalance = _accountBalance - amountToWithdraw;
                return true;
            }

            public decimal GetBalance()
            {
                return _accountBalance;
            }
        }

        class OverdraftAccount : BankAccount
        {
            decimal overdraftLimit = 100;
            Address GuarantorAddress;
        }

        class Report : IPrintable
        {

        }

        static void Main(string[] args)
        {
            #region Using interop   

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

            #endregion

            Customer c = new Customer();
            c.Nome = "Rafael";

            Console.WriteLine($"Customer name: {c.Nome}");

            c.PrivateName = "Rafael Cruz";
            Console.WriteLine($"Customer name: {c.PrivateName}");

            BankAccount a = new BankAccount();
            a.PayInFunds(50);
            Console.WriteLine($"Pay in 50");
            a.PayInFunds(50);

            if (a.WithdrawFunds(10))
                Console.WriteLine("Withdraw 10.");
            Console.WriteLine($"Account balance is: {a.GetBalance()}");

            Console.ReadKey();
        }
    }

    internal interface IPrintable
    {
    }
}
