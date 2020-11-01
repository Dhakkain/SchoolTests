using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace SchoolTests.Module3
{
    public class StringCalculator
    {
        public string Add(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return "0";
            }

            Regex regex = new Regex("-[0-9]+|[0-9]+");
            var splittedString = regex.Matches(number);

            CheckNegativeNumbers(splittedString);

            return CalculateSum(splittedString);
        }

        private string CalculateSum(MatchCollection splittedString)
        {
            int sum = 0;
            foreach (var item in splittedString)
            {
                if (int.TryParse(item.ToString(), out int parsedNumber))
                {
                    if (parsedNumber < 1000)
                    {
                        sum += parsedNumber;
                    }
                }
            }

            return sum.ToString();
        }

        private void CheckNegativeNumbers(MatchCollection splittedString)
        {
            var negatives = splittedString.Where(x => x.Value.StartsWith("-"));

            if (negatives.Any())
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendJoin(',', negatives);
                throw new NegativeNumberException("Negatives not allowed: " + stringBuilder);
            }
        }
    }
}
