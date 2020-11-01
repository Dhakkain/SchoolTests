using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Module3
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {
        }

        public NegativeNumberException(string message)
            : base(message)
        {
        }

        public NegativeNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
