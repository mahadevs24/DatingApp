using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class APIException
    {
        public APIException(int _statusCode, string _Message, string _Details)
        {
            this.StatusCode = _statusCode;
            this.Message = _Message;
            this.Details = _Details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}