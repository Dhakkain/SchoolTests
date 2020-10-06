using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Module2
{
    public interface IVatProvider
    {
        public double GetDefaultVat();

        public double GetVatForType(string type);
    }
}
