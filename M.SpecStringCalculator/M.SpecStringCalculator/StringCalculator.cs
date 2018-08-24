using System;
using System.Linq;

namespace M.SpecStringCalculator
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var separator = new char[] { ',', '\n', ';', '*','^','#','@','!','&',':','?','|','%','$','~','`','.','<','>','_','+','='};
            var output = input
                .Replace(")",string.Empty)
                .Replace("(", string.Empty)
                .Replace("}",string.Empty)
                .Replace("{",string.Empty)
                .Replace("]", string.Empty)
                .Replace("[", string.Empty)
                .Replace("//", string.Empty)
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var negativeValues = output.Where(x => int.Parse(x) < 0);
            if (negativeValues.Any())
            {
                throw new Exception($"Negatives are not allowed {input}");
            }
            return output.Where(x => int.Parse(x) < 1000).Sum(int.Parse);
        }
    }
}