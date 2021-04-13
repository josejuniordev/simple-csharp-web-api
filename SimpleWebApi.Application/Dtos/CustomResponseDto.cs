using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApi.Application.Dtos
{
    public class CustomResponseDto<T>
    {
        public CustomResponseDto(bool success, IList<string> errors, T data, string message, int statusCode = StatusCodes.Status200OK)
        {
            Success = success;
            Errors = errors;
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }

        public bool Success { get; set; }
        public IList<string> Errors { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
