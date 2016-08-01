using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoHelper.HelperMethods
{
    static class StringExtension
    {
        public static int MaxDigitCount(this string str)
        {
            int maxCountDigit=0;
            int tempCount = 0;
            foreach (var item in str)
            {
                if(char.IsDigit(item))
                {
                    tempCount++;
                }
                else
                {
                    maxCountDigit = tempCount > maxCountDigit ? tempCount : maxCountDigit;
                    tempCount = 0;
                }
            }
            return maxCountDigit;
        }
    }
}
