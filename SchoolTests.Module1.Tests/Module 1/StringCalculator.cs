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
        public void ShouldReturn()
        {
            var result = stringCalculator.Add("");
            Assert.AreEqual(result, 0);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("1,2", 3 )]
        [TestCase("1,2,3", 6)]
        [TestCase("5,5,5", 15)]
        public void ShouldReturnSumWhenGivenNumber(string input, int sum)
        {
            var result = stringCalculator.Add(input);
            Assert.AreEqual(result, sum);
        }

    }
}