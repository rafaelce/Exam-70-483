using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._4_Create_and_Implement_a_Class_Hierarchy
{
    class Program
    {
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

            public virtual bool WithdrawFunds(decimal amount)
            {
                if (_balance < amount)
                    return false;

                _balance = _balance - amount;
                return true;
            }
        }

        public class BabyAccount : BankAccount, IAccount
        {
            //public override bool WithdrawFunds(decimal amount)
            //{
            //    if (amount > 10)
            //    {
            //        return false;
            //    }

            //    if (_balance < amount)
            //    {
            //        return false;
            //    }

            //    _balance = _balance = amount;
            //    return true;
            //}

            public override bool WithdrawFunds(decimal amount)
            {
                if (amount > 10)
                {
                    return false;
                }
                else
                {
                    return base.WithdrawFunds(amount);
                }

            }
        }

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
            IAccount account = new BankAccount();
            account.PayInFunds(50);

            Console.WriteLine($"Balance: {account.GetBalance()}");

            IAccount baby = new BabyAccount();
            baby.PayInFunds(50);

            if (baby is IAccount)
                Console.WriteLine("\nthis object can be used as an account.");
            else
                Console.WriteLine("\nthis object cannot be used as an account.");


            Console.ReadKey();
        }

    }
}
