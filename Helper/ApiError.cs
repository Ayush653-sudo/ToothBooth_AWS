using Microsoft.AspNetCore.Http;
using System;

namespace Tooth_Booth_API.Helper
{
    public class ApiError:Exception
    {
        public int statusCode {  get; set; }
        public string message { get; set; }
        public ApiError(int StatusCode,string message) 
        { 
            this.statusCode = StatusCode;
            this.message = message;

        }
    }
}
