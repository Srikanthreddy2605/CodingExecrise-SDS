using System;
using System.Globalization;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Cant calculate for -ve Numbers");
            }
            int output = 1;
            //instead of using recursion methods , I am using a loop to calculate factorial
            //recurison may cause stack overflow for large numbers.
            for (int i = 2; i <= n; i++)
            {
                output *= i;
            }
            return output;
        }


        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
                return string.Empty;
            //Instead of using String.Join, we can using loop to format the items
            var lstAllItemsExcptLast = string.Join(", ", items.Take(items.Length - 1));           
            return $"{lstAllItemsExcptLast} and {items[^1]}";
        }

       
    }
}