using NUnit.Framework;
using SchoolTests.Module2;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.ComponentModel;

namespace SchoolTests.Module2.Tests
{
    [TestFixture()]
    public class VatServiceTests
    {
        private VatService vatService;

        [SetUp]
        public void SetUp()
        {
            vatService = new VatService();
        }


        [Test]
        [TestCase(10.00, 12.3)]
        [TestCase(20.00, 24.6)]
        [TestCase(100.00, 123)]
        public void ShouldReturnGrossPriceForDefaultVatGiven(double netPrice, double outPrice)
        {
            //// Given
            Product product = new Product(Guid.NewGuid().ToString(), netPrice);
           
            //// When
            var result = vatService.GetGrossPriceForDefaultVat(product);

            //// Then
            result.Should().Be(outPrice);
        }

        [Test]
        [TestCase(10.00, 0.1, 11)]
        [TestCase(20.00, 0.66, 33.2 )]
        [TestCase(100.00, 0.99, 199)]
        public void ShouldReturnGrossPriceForVatGiven(double netPrice, double vatValue,  double outPrice)
        {
            var result = vatService.GetGrossPrice(netPrice, vatValue);

            result.Should().Be(outPrice);
        }

        [Test]
        public void ShouldThrowExceptionWhenVatBiggerThenOneGiven()
        {
            double vat = 25.33;
            double netPrice = 10.00;

            Action action = () => vatService.GetGrossPrice(netPrice, vat);

            action.Should().Throw<Exception>();
        }
    }
}