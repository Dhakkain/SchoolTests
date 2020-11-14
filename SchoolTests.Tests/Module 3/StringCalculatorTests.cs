using FluentAssertions;
using NUnit.Framework;
using SchoolTests.Module3;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Tests.Module3
{
    [TestFixture()]
    public class StringCalculatorTests
    {
        [Test()]
        [TestCase("1,2,3,4", "10")]
        [TestCase("5,10", "15")]
        public void ShouldReturnSumOfNumberFromString(string input, string sum)
        {
            var stringCalculator = new StringCalculator();

            var result  = stringCalculator.Add(input);

            result.Should().Be(sum);

        }

        [Test()]
        public void ShouldReturnZeroWhenStringEmptyGiven()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("");

            result.Should().Be("0");

        }

        [Test()]
        [TestCase("1\n2,3", "6")]
        [TestCase("1,\n", "1")]
        [TestCase("//;\n1;2", "3")]
        public void ShouldReturnSumOfNumberFromStringWithSpecialCharacter(string input, string sum)
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(input);

            result.Should().Be(sum);
        }

        [Test()]
        [TestCase("-1")]
        [TestCase("-2,-4")]

        public void ShouldThrowExceptionWhenNegativeNumberGiven(string input)
        {
            var stringCalculator = new StringCalculator();

            Action action = () => stringCalculator.Add(input); 

            action.Should().Throw<NegativeNumberException>();
        }


        [Test()]
        [TestCase("-2,-4,5,6", "-2,-4")]
        [TestCase("-3,-1,-15,2", "-3,-1,-15")]
        public void ShouldThrowExceptionWithMessageContainsFoundNegativeNumberWhenNegativeNumberGiven(string input, string negativeNumber)
        {
            var stringCalculator = new StringCalculator();

            Action action = () => stringCalculator.Add(input);

            action.Should().Throw<NegativeNumberException>().WithMessage("Negatives not allowed: " + negativeNumber);
        }



    }
}