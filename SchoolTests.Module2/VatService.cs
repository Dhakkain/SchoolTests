using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Module2
{
    public class VatService
    {
        public double VatValue { get; set; }

        public VatService()
        {
            this.VatValue = 0.23;
        }

        public double GetGrossPriceForDefaultVat(Product product)
        {
            return GetGrossPrice(product.NetPrice, VatValue);
        }

        public double GetGrossPrice(double netPrice, double vatValue)
        {
            if (vatValue > 1)
            {
                throw new Exception();
            }

            return netPrice * (1 + vatValue);
        }
    }
}
