using System.Collections.Generic;
using FizzBuzz.Core;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(2, true)]
        [TestCase(3,true)]
        [TestCase(90, false)]
        [TestCase(11, true)]
        [TestCase(17, true)]
        [TestCase(28, false)]
        public void CheckIfNumberisPrime(int input, bool expectedVal)
        {
            bool actualVal = Helper.IsNumberPrime((ulong)input);
            Assert.That(actualVal, Is.EqualTo(expectedVal));
        }

        [Test]
        public void IfConfigHasPrimeNumber_ThatCanDivideInput_ReturnCorrectString()
        {
            var sut = new FizzBuzzService(1, 100);
            var dict = new Dictionary<ulong, string> { { 3, "Foo" } };
            string actualValue = sut.ProcessFizzBuzz(39, dict);
            Assert.That(actualValue, Is.EqualTo(dict[3]));
        }

        [Test]
        public void IfConfigHasCompositeNumber_ThatCanDivideInput_AndNoPairOfFactorsExist_ReturnCorrectString()
        {
            var sut = new FizzBuzzService(1, 100);
            var dict = new Dictionary<ulong, string> { { 12, "Foo" } };
            string actualValue = sut.ProcessFizzBuzz(24, dict);
            Assert.That(actualValue, Is.EqualTo(dict[12]));
        }

        [Test]
        public void IfConfigHasCompositeNumber_ThatCanDivideInput_AndPairOfFactorsExist_ReturnCorrectString()
        {
            var sut = new FizzBuzzService(1, 100);
            var dict = new Dictionary<ulong, string> { { 12, "Foo" }, { 3, "Fizz" }, { 4, "Buzz" } };
            string actualValue = sut.ProcessFizzBuzz(24, dict);
            Assert.That(actualValue, Is.EqualTo("FizzBuzz"));

        }

        [Test]
        public void IfConfigHasTwoNumbers_ThatCanDivideSameInput_ReturnCorrectString()
        {
            var sut = new FizzBuzzService(1, 100);
            var dict = new Dictionary<ulong, string> { { 5, "Foo" }, { 3, "Fizz" }, { 4, "Buzz" } };
            string actualValue = sut.ProcessFizzBuzz(20, dict);
            Assert.That(actualValue, Is.EqualTo("FooBuzz"));
        }

        [Test]
        public void CheckListofFactorsForGivenInput()
        {
            ulong actualVal = 0;
            const ulong expectedVal = 15;
            foreach (var key in Helper.ListOfFactors(8))
            {
                actualVal += key;
            }
            Assert.That(actualVal, Is.EqualTo(expectedVal));
        }

        [Test]
        public void CanProgramAcceptLongNumbers()
        {
            var sut = new FizzBuzzService(1, 100);
            var dict = new Dictionary<ulong, string> { { 5, "Foo" }, { 3, "Fizz" } };
            string actualValue = sut.ProcessFizzBuzz(ulong.MaxValue, dict);
            Assert.That(actualValue, Is.EqualTo("FooFizz"));
            
        }

    }
}
