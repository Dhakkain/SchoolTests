using NUnit.Framework;
using SchoolTests.Module2;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.ComponentModel;
using Moq;

namespace SchoolTests.Tests.Module2
{
    [TestFixture()]
    public class VatServiceTests
    {
        private VatService vatService;

        private Mock<IVatProvider> vatProvider;

        [SetUp]
        public void SetUp()
        {
            vatProvider = new Mock<IVatProvider>();
            vatService = new VatService(vatProvider.Object);
        }


        [Test]
        [TestCase(10.00, 12.3)]
        [TestCase(20.00, 24.6)]
        [TestCase(100.00, 123)]
        public void ShouldReturnGrossPriceForDefaultVatGiven(double netPrice, double outPrice)
        {
            //// Given
            Product product = new Product(Guid.NewGuid().ToString(), netPrice);

            var defaultVat = 0.23;
            vatProvider.Setup(x => x.GetDefaultVat()).Returns(defaultVat);

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
            vatProvider.Setup(x => x.GetDefaultVat()).Returns(vatValue);

            var result = vatService.CalculatePrice(netPrice, vatValue);

            result.Should().Be(outPrice);
        }


        [Test]
        public void ShouldReturnPriceDependsOnProductTypeVat()
        {
            var vatTestType = 0.23;
            var netPrice = 100;
            var productType = "TestType";

            vatProvider.Setup(x => x.GetVatForType(productType)).Returns(vatTestType);

            var result = vatService.GetGrossPriceForProductType(netPrice, productType);

            result.Should().Be(123);
        }


        [Test]
        public void ShouldThrowExceptionWhenVatBiggerThenOneGiven()
        {
            double vat = 25.33;
            double netPrice = 10.00;

            Action action = () => vatService.CalculatePrice(netPrice, vat);

            action.Should().Throw<Exception>();
        }
    }
}