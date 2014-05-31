using System;
using System.Collections;
using System.Collections.Generic;

namespace FizzBuzz.Core
{
    public static class Helper
    {
        public static bool IsNumberPrime(ulong inputVal)
        {
            // check for 2 as first prime
            // check for primes from 3 to SQRT(inputVal) - excluding all even numbers
            if (inputVal == 1) return false;
            if (inputVal == 2) return true;
            if (inputVal%2 == 0) return false;
            var isPrime = true;
            for (ulong i = 3; i <= Math.Sqrt(inputVal); i++)
            {
                if (inputVal%i == 0)
                {
                    isPrime = false;
                    break;
                }

            }
            return isPrime;
        }

        public static IEnumerable<ulong> ListOfFactors(ulong inputVal)
        {
            ulong max = inputVal / 2;
            for (ulong i = 1; i <= max; i++)
            {
                if (0 == (inputVal % i))
                {
                    yield return i;
                }
            }
            yield return inputVal;
        }
    }
}