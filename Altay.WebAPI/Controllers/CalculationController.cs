using Altay.Business.Managements;
using Altay.Entities.Models.Result;
using Altay.WebAPI.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Altay.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : Controller
    {
        [HttpPost("CalculateClosestPrimeNumber")]
        public IActionResult CalculateClosestPrimeNumber([FromForm] string NumberString)
        {
            ResultObject<int> resultObject = new ResultObject<int>();
            
            if (!ModelState.IsValid) 
            {
                return Redirect("~/Index");
            }
            
            CalculationManagement calculationMan = new CalculationManagement();

            var numberList = NumberString.Split(',').Select(c => Convert.ToInt32(c)).ToList();
            
            resultObject = calculationMan.CalculateClosestPrimeNumber(numberList);
            resultObject.ResultCode = Entities.Enums.enGeneral.Results.OK;
            TempData["result"] = resultObject.Object;
            TempData["inputText"] = NumberString;
            return Redirect("~/Index");
        }
    }
}
