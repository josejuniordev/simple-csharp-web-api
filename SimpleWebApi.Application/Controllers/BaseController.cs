using System.Collections.Generic;
using SimpleWebApi.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApi.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<CustomResponseDto<T>> CustomResponse<T>(T data, IList<string> errors, string message, bool isValid = true, int statusCode = StatusCodes.Status200OK)
        {
            return StatusCode(statusCode, new CustomResponseDto<T>(isValid, errors, data, message, statusCode));
        }
    }
}