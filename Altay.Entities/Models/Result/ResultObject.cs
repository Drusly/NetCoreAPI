using System;
using System.Collections.Generic;
using System.Text;
using static Altay.Entities.Enums.enGeneral;

namespace Altay.Entities.Models.Result
{
    public class ResultObject<T> 
    {
        public T Object { get; set; }
        public Results ResultCode { get; set; }
        public string Message { get; set; }
    }
}
