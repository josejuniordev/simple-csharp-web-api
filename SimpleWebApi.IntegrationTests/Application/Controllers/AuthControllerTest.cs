using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Application.Controllers;
using SimpleWebApi.Application.Dtos;
using Xunit;

namespace SimpleWebApi.IntegrationTests.Application.Controllers
{
    public class AuthControllerTest
    {
        [Fact]
        public void ValidatePasswordReturnsTheAppropriateActionResult()
        {
            //arrange
            var controller = new AuthController();
            
            //act
            var result = controller.ValidatePassword(new PasswordValidationDto { Password = "" });
            
            //assert
            Assert.IsAssignableFrom<ActionResult<CustomResponseDto<PasswordValidationResultDto>>>(result);
        }
        
        [Fact]
        public void ValidatePasswordReturnsStatusCode200()
        {
            //arrange
            var controller = new AuthController();
            
            //act
            var response = controller.ValidatePassword(new PasswordValidationDto { Password = "" });
            var result = (ObjectResult) response.Result;
            
            //assert
            Assert.Equal(200, result.StatusCode);
        }
        
        [Fact]
        public void ValidatePasswordReturnsStatusCodeFromDtoAttributesCorrectlyFilled()
        {
            //arrange
            var controller = new AuthController();
            
            //act
            var response = controller.ValidatePassword(new PasswordValidationDto { Password = "" });
            var result = (ObjectResult) response.Result;
            var value = (CustomResponseDto<PasswordValidationResultDto>) result.Value;
            
            //assert
            Assert.Equal(200, value.StatusCode);
        }
        
        [Theory]
        [InlineData("", false)]
        [InlineData("Abcdefghi8*!", true)]
        public void ValidatePasswordReturnsSuccessAttributeFromDtoCorrectlyFilled(string password, bool expectedValue)
        {
            //arrange
            var controller = new AuthController();
            
            //act
            var response = controller.ValidatePassword(new PasswordValidationDto { Password = password });
            var result = (ObjectResult) response.Result;
            var value = (CustomResponseDto<PasswordValidationResultDto>) result.Value;
            
            //assert
            Assert.Equal(expectedValue, value.Success);
        }
        
        [Theory]
        [InlineData("", false)]
        [InlineData("Abcdefghi8*!", true)]
        public void ValidatePasswordReturnsADtoWithAnAttributeOfTypePasswordValidationResultDtoCorrectlyFilled(string password, bool expectedValue)
        {
            //arrange
            var controller = new AuthController();
            
            //act
            var response = controller.ValidatePassword(new PasswordValidationDto { Password = password });
            var result = (ObjectResult) response.Result;
            var value = (CustomResponseDto<PasswordValidationResultDto>) result.Value;
            
            //assert
            Assert.Equal(expectedValue, value.Data.PasswordIsValid);
        }
    }
}