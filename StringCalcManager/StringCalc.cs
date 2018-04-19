using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalcManager
{
    public class StringCalc
    {
        const char delimiter = ',';
        public static int Add(string numbers)
        {
            
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else
            {
                if (numbers.EndsWith("\n"))
                {
                    throw new NotSupportedException("Non è possibile terminare con una nuova linea");
                }
                else
                {

                    var stringNumbersArray = numbers.Replace('\n', delimiter)
                                                    .Split(delimiter);

                    GetNumbersArrayDefaultDelimiter(ref stringNumbersArray);
                    var numbersArray = stringNumbersArray.Where(x=>!string.IsNullOrEmpty(x))
                                                         .Select(x => int.Parse(x))
                                                         .ToArray();
                    ValidateNonNegatives(numbersArray);

                    return numbersArray.Where(x=>x<1000)
                                       .Sum(x => x);
                }
            }
        }

        private static void ValidateNonNegatives(int[] numbersArray)
        {
            if (numbersArray.Any(x => x < 0))
                throw new Exception($"negatives not allowed:{string.Join(" ", numbersArray.Where(x => x < 0))}");
        }

        private static void GetNumbersArrayDefaultDelimiter(ref string[] stringNumbersArray)
        {

            if (!stringNumbersArray[0].StartsWith("//"))
                return;
            
            var customDelimiters = stringNumbersArray[0].Remove(0, 2).Distinct();
            foreach (var customDelimiter in customDelimiters)
            {
                stringNumbersArray[1] = stringNumbersArray[1].Replace(customDelimiter, delimiter);
            }
            //stringNumbersArray[1] = stringNumbersArray[1].Replace(customDelimiter, delimiter.ToString());
            stringNumbersArray = stringNumbersArray[1].Split(delimiter);
        }
    }
}
