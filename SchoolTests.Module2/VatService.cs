using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Module2
{
    public class VatService
    {
        private readonly IVatProvider vatProvider;

        public VatService(IVatProvider vatProvider)
        {
            this.vatProvider = vatProvider;
        }

        public double GetGrossPriceForDefaultVat(Product product)
        {
            return CalculatePrice(product.NetPrice, vatProvider.GetDefaultVat());
        }

        public double GetGrossPriceForProductType(double netPrice, string productType)
        {
            var vatValue = this.vatProvider.GetVatForType(productType);
            return CalculatePrice(netPrice, vatValue);
        }


        public double CalculatePrice(double netPrice, double vatValue)
        {
            if (vatValue > 1)
            {
                throw new Exception();
            }

            return netPrice * (1 + vatValue);
        }
    }
}
