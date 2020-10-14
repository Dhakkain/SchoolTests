using NUnit.Framework;
using SchoolTests.Module1;
using System;

namespace SchoolTests.Tests.Module1
{
    public class StringCalculatorTests
    {
        StringCalculator stringCalculator;

        [SetUp]
        public void Setup()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void ShouldReturnZeroWhenEmptyString()
        {
            var result = stringCalculator.Add("");
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void ShouldReturnZeroWhenNull()
        {
            var result = stringCalculator.Add(null);
            Assert.AreEqual(result, 0);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("5,5,5", 15)]
        public void ShouldReturnSumWhenPositiveNumberGiven(string input, int sum)
        {
            var result = stringCalculator.Add(input);
            Assert.AreEqual(result, sum);
        }


        [Test]
        [TestCase("-2", -2)]
        [TestCase("-1,-1", -2)]
        [TestCase("-1,-2,-3", -6)]
        public void ShouldReturnSumWhenNegativeNumberGiven(string input, int sum)
        {
            var result = stringCalculator.Add(input);
            Assert.AreEqual(result, sum);
        }


    }
}