using Altay.Business.Managements;
using Altay.Entities.Models.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altay.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpPost("CalculateClosestPrimeNumber")]
        public ResultObject<int> CalculateClosestPrimeNumber(string numberString)
        {
            ResultObject<int> resultObject = new ResultObject<int>();

            if (!ModelState.IsValid) 
            {
                return resultObject;   
            }

            
            CalculationManagement calculationMan = new CalculationManagement();

            var numberList = numberString.Split(',').Select(c => Convert.ToInt32(c)).ToList();
            
            resultObject = calculationMan.CalculateClosestPrimeNumber(numberList);
            resultObject.ResultCode = Entities.Enums.enGeneral.Results.OK;
            return resultObject;
        }
    }
}
