using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApiResult<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public ApiResult() { }
        public ApiResult(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public ApiResult<T> Failed(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            IsSuccess = false;
            return this;
        }
        public ApiResult<T> Succeed(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            IsSuccess = true;
            return this;
        }
    }
}
