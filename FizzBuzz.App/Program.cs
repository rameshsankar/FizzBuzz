using System;
using FizzBuzz.Core;

namespace FizzBuzz.App
{
    class Program
    {
        private static ulong _lowerVal;
        private static ulong _upperVal;

        static void Main()
        {
            Console.WriteLine("****************");
            Console.WriteLine("FIZZBUZZ SERVICE");
            Console.WriteLine("****************");
            Console.WriteLine("Range Start Value: ");
            string lowerInput = Console.ReadLine();

            Console.WriteLine("Range End Value: ");
            string upperInput = Console.ReadLine();

            try
            {
                RunFizzBuzz(lowerInput, upperInput);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Arguments out of Range");
            }

            catch (OverflowException)
            {
                Console.WriteLine("Invalid Arguments entered");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

            Console.WriteLine("\n");
            Console.WriteLine("***********************");
            Console.WriteLine("Press Enter Key to Exit");
            Console.WriteLine("***********************");
            Console.ReadLine();

        }

        private static void RunFizzBuzz(string lowerInput, string upperInput)
        {
            if (!String.IsNullOrEmpty(lowerInput))
                _lowerVal = ulong.Parse(lowerInput);

            if (!String.IsNullOrEmpty(upperInput))
                _upperVal = ulong.Parse(upperInput);
            var service = new FizzBuzzService(_lowerVal, _upperVal);
            service.Print();
        }
    }
}
