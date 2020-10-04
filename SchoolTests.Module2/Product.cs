using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Module2
{
    public class Product
    {
        public Product(string id, double netPrice)
        {
            Id = id;
            NetPrice = netPrice;
        }
        public string Id { get; set; }
        public double NetPrice { get; set; }

    }
}
