using Altay.Entities.Models.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Altay.Business.Utility;

namespace Altay.Business.Managements
{
    public class CalculationManagement
    {
        public ResultObject<int> CalculateClosestPrimeNumber(List<int> request)
        {
            ResultObject<int> result = new ResultObject<int>();
            
            try
            {
                var biggerPrimeNumber = 0;
                var lowerPrimeNumber = 0;
                
                var sortedNumberList = request.OrderByDescending(c => c).ToList();
                var highestValue = sortedNumberList.FirstOrDefault();
                if(highestValue == 0)
                {
                    result.Message = "Object Prime Number Couldn't Calculate";
                    return result;
                }

                if(highestValue <= 2)
                {
                    result.Object = 2;
                    return result;
                }

                for(int i = highestValue; i > 0; i--)
                {
                    if (MathUtility.isPrime(i))
                    {
                        lowerPrimeNumber = i;
                        break;
                    }
                }

                var nextNumber = highestValue + 1;
                while (MathUtility.isPrime(nextNumber) == false)
                {
                    nextNumber++;
                }

                biggerPrimeNumber = nextNumber;

                var lowerCheck = highestValue - lowerPrimeNumber;
                var higherCheck = biggerPrimeNumber - highestValue;
                if(lowerCheck < higherCheck)
                {
                    result.Object = lowerPrimeNumber;
                }
                else
                {
                    result.Object = biggerPrimeNumber;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ResultCode = Entities.Enums.enGeneral.Results.InternalServerError;
            }

            return result;
        }
    }
}
