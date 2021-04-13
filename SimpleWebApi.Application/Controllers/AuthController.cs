using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleWebApi.Application.Dtos;
using SimpleWebApi.Core.DomainObjects.ValueObjects;

namespace SimpleWebApi.Application.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : BaseController
    {
        public AuthController()
        { }

        [HttpPost("validate-password")]
        public ActionResult<CustomResponseDto<PasswordValidationResultDto>> ValidatePassword(PasswordValidationDto data)
        {
            try
            {
                var password = new Password(data.Password);
                
                if (password.Validate())
                    return CustomResponse(new PasswordValidationResultDto(true), null, "Password Válido");

                return CustomResponse(new PasswordValidationResultDto(false), null, "Password Inválido", false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CustomResponse<PasswordValidationResultDto>(null, null, e.Message);
            }
        }
    }
}