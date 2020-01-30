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

        interface IAccount
        {
            void PayInFunds(decimal amount);
            bool WithdrawFunds(decimal amount);
            decimal GetBalance();
        }

        public class BankAccount : IAccount
        {
            private decimal _balance = 0;
            decimal IAccount.GetBalance()
            {
                return _balance;
            }

            void IAccount.PayInFunds(decimal amount)
            {
                _balance = _balance + amount;
            }

            bool IAccount.WithdrawFunds(decimal amount)
            {
                if (_balance < amount)
                    return false;

                _balance = _balance - amount;
                return true;
            }
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
