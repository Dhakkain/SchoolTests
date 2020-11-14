using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Module3
{
    public class Frame
    {
        public int? FirstThrow { get; set; }
        public int? SecondThrow { get; set; }


        public bool IsSpare()
        {
            return FirstThrow + SecondThrow == 10;
        }

        public bool IsStrike()
        {
            return FirstThrow == 10;
        }
    }
}
