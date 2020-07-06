using System;
using System.Collections.Generic;

namespace Test_design_patterns_Part_2_Question_2
{
    class Program
    {
        static private Stack<int> _stack = new Stack<int>();
        static private int _maxNumber = int.MinValue;
        static private int _minNumber = int.MaxValue;

        static string _theLastNumberStr = string.Empty;


        static void Main(string[] args)
        {

            Action a = () => 
            {
                Console.WriteLine($"The last n umber in the stack is: {_stack.Peek()}");
            };
            ProcessExceptions(a);

            int[] arrayOfNumbers;
            do
            {
                arrayOfNumbers = (int[])PleaseEnterSomeNumbers(1).Clone();
                int number = arrayOfNumbers[0];

                if (number != -1)
                {
                    if (number > _maxNumber) _maxNumber = number;
                    if (number < _minNumber) _minNumber = number;
                    _stack.Push(number);
                }
            }
            while (arrayOfNumbers[0] != -1);

            Console.WriteLine("Do you want to see the last number you just entered,\n and the minimal and the maximal numbers amongst them? Press \"y\" or \"n\"");
            Console.WriteLine("\n");
            if(YesOrNo())
            {
                Console.WriteLine("\n");
                a = () => 
                {
                    Console.WriteLine($"The last number yo entered is {_stack.Peek()}");
                };
                ProcessExceptions(a);
                

                Console.WriteLine("Do you want to take this number out of the stack? Press \"y\" or \"n\"");
                if (YesOrNo())
                {
                    Console.WriteLine("\n");
                    a = () =>
                    {
                        Console.WriteLine($"The last number \"{_theLastNumberStr = _stack.Pop().ToString()}\" just taken out of the stack.\n\n");
                    };
                    ProcessExceptions(a);
                }
                else Console.WriteLine("The last number wasn't taken out of the stack.\n\n");
                

                string min = string.Empty;
                string max = string.Empty;
                do
                {
                    if (Int32.TryParse(_theLastNumberStr, out int num))
                    {
                        _theLastNumberStr = string.Empty;
                    }
                    else num = _stack.Pop();


                    if (num == _maxNumber) max = num.ToString();
                    if (num == _minNumber) min = num.ToString();

                    if (min != string.Empty && max != string.Empty) break;
                }
                while (_stack.Count > 0);

                Console.WriteLine($"The maximal number of those you had entered is: {max},\nthe minimal one is: {min}");
            }


            Console.ReadKey(); 
        }


        static protected void ProcessExceptions(Action act)
        {
            try
            {
                act();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The stack is empty\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name}\n\n{ex.Message}\n\n\n{ex.StackTrace}");
            }
                
        }































        public static int[] PleaseEnterSomeNumbers(int iterations)
        {
            if (iterations == 1) { Console.WriteLine("Please enter one number:\nTo exit, enter \"-1\"\n"); }
            else { Console.WriteLine("Please enter {0} numbers:\n", iterations); }

            int[] arriterations = new int[iterations];

            for (int i = 0; i < iterations; i++)
            {
                if (Int32.TryParse(Console.ReadLine(), out int line)) arriterations[i] = line;
                else { i--; Console.WriteLine("\n This is not a number! \nPlease enter only numbers. \nNow lets try again: \n"); }
            }
            return arriterations;
        }

        public static bool YesOrNo()
        {
            char yOrN = default(char);
            do
            {
                yOrN = Console.ReadKey().KeyChar;
                if (yOrN != 'y' && yOrN != 'n') Console.WriteLine("\nPlease pressonly \"y\" or \"n\"!");
            }
            while (yOrN != 'y' && yOrN != 'n');
            if (yOrN == 'y') return true;
            else return false;
        }
    }

    










}
