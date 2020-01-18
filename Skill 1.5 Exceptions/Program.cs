using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_1._5_Exceptions
{
        class Program
        {
            static void Main(string[] args)
            {
                //exceptionOne();

                //exceptionTwo();

                //exceptionThree();

                exceptionWithFinaly();

                Console.ReadKey();

            }

            static void exceptionOne()
            {
                try
                {
                    Console.Write(" Enter an integer: ");
                    string numberText = Console.ReadLine();
                    int result; result = int.Parse(numberText);
                    Console.WriteLine($" You entered {result}");
                }
                catch
                {
                    Console.WriteLine(" Invalid number entered");
                }
            }

            static void exceptionTwo()
            {
                try
                {
                    Console.Write(" Enter an integer: ");
                    string numberText = Console.ReadLine();
                    int result;

                    result = int.Parse(numberText);
                    Console.WriteLine($" You entered {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Message: {ex.Message}");
                    Console.WriteLine($" Stacktrace: {ex.StackTrace}");
                    Console.WriteLine($" HelpLink: {ex.HelpLink}");
                    Console.WriteLine($" TargetSite: {ex.TargetSite}");
                    Console.WriteLine($" Source: {ex.Source}");
                }

            }

            static void exceptionThree()
            {
                try
                {
                    Console.Write(" Enter an integer: ");

                    string numberText = Console.ReadLine();

                    int result;
                    result = int.Parse(numberText);

                    Console.WriteLine(" You entered {0}", result);
                    int sum = 4 / result;

                    Console.WriteLine(" Sum is {0}", sum);
                }
                catch (NotFiniteNumberException nx)
                {
                    Console.WriteLine(" Invalid number");
                }
                catch (DivideByZeroException zx)
                {
                    Console.WriteLine(" Divide by zero");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Unexpected exception");
                }

            }

            static void exceptionWithFinaly()
            {
                try
                {
                    Console.Write(" Enter an integer: ");
                    string numberText = Console.ReadLine();
                    int result; result = int.Parse(numberText);

                    Console.WriteLine(" You entered {0}", result); int sum = 1 / result; Console.WriteLine(" Sum is {0}", sum);
                }
                catch (NotFiniteNumberException nx) { Console.WriteLine(" Invalid number"); }
                catch (DivideByZeroException zx) { Console.WriteLine(" Divide by zero"); }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("Something bad happened.", ex);
                }
                finally { Console.WriteLine(" Thanks for using my program."); }

            }

            static void myException()
            {
                try
                {
                    throw new Exception("I think you should know that I'm feeling very depressed.");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }


            }
        }
}
