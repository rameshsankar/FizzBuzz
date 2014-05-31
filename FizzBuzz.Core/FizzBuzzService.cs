using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace FizzBuzz.Core
{
    public class FizzBuzzService
    {
        public ulong LowerVal { get; set; }
        public ulong UpperVal { get; set; }
        private readonly Dictionary<ulong, string> _fbDictionary = new Dictionary<ulong, string>();

        public FizzBuzzService()
            : this(1, 100)
        {
        }

        public FizzBuzzService(ulong lowerVal, ulong upperVal)
        {
            if (lowerVal > upperVal)
                throw new ArgumentOutOfRangeException();
            if (lowerVal <= 0)
                throw new ArgumentOutOfRangeException();
            LowerVal = lowerVal;
            UpperVal = upperVal;
            InitializeRules(_fbDictionary);
        }

        public void InitializeRules(Dictionary<ulong, string> fbDictionary)
        {
            if (fbDictionary == null) throw new ArgumentNullException("fbDictionary");
            // Retrieve from Config
            var fizzBuzzRetriever = ConfigurationManager.GetSection("fizzbuzzRuleRetriever") as NameValueCollection;
            if (fizzBuzzRetriever == null) return;
            foreach (var divisor in fizzBuzzRetriever.AllKeys)
            {
                string outputVal = fizzBuzzRetriever.GetValues(divisor).FirstOrDefault();
                if (!string.IsNullOrEmpty(outputVal))
                {
                    fbDictionary.Add(ulong.Parse(divisor), outputVal);
                }
            }
        }


        public string ProcessFizzBuzz(ulong i, Dictionary<ulong, string> fbDictionary)
        {
            string returnVal = i.ToString(CultureInfo.CurrentCulture);
            foreach (var item in fbDictionary)
            {
                // If input is a Prime number, return fizzbuzz output
                if (Helper.IsNumberPrime(item.Key))
                {
                    if (i % item.Key == 0)
                    {
                        if (returnVal != i.ToString(CultureInfo.CurrentCulture)) returnVal += item.Value;
                        else
                            returnVal = item.Value;
                    }
                }
                else
                {
                    // If Divisor is not a prime number, check if any pair of factors are in dictionary
                    if (i % item.Key == 0)
                    {
                        foreach (var factor in Helper.ListOfFactors(item.Key))
                        {
                            if (!fbDictionary.ContainsKey(factor)) continue;
                            // If pair exits, concatenate (e.g. FizzBuzz Condition)
                            if ((fbDictionary.ContainsKey(item.Key / factor))
                                && (fbDictionary.ContainsKey(factor)) && (item.Key / factor != factor))
                            {
                                returnVal = fbDictionary[factor] + fbDictionary[item.Key / factor];
                                break;
                            }

                            // Eliminate Duplicate Concats
                            if (returnVal != i.ToString(CultureInfo.CurrentCulture) 
                                && (!returnVal.Contains(item.Value))) returnVal += item.Value;
                            else
                                returnVal = item.Value;


                        }

                        break;

                    }
                }

            }
            return returnVal;
        }

        public void Print()
        {
            for (ulong i = LowerVal; i <= UpperVal; i++)
            {
                Console.WriteLine(ProcessFizzBuzz(i, _fbDictionary));
            }
        }
    }
}
