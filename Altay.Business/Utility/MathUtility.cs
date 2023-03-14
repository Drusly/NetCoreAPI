using System;
using System.Collections.Generic;
using System.Text;

namespace Altay.Business.Utility
{
    public static class MathUtility
    {
        public static bool isPrime(int value)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(value));

            for (int i = 2; i <= boundary; ++i)
            {
                if (value % i == 0) return false;
            }

            return true;
        }
    }
}
