using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests.Module1
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            int result = 0;

            if (string.IsNullOrEmpty(input))
            {
                return result;
            }
            else
            {
                string[] numbers = input.Split(',');

                foreach (var number in numbers)
                {
                    result += int.Parse(number);
                }
              
                return result;
            }
        }
    }
}
