using System;
using SimpleWebApi.Core.DomainObjects.Exceptions;
using SimpleWebApi.Core.DomainObjects.ValueObjects;
using Xunit;

namespace SimpleWebApi.Tests.Unit.Core.DomainObjects.ValueObjects
{
    public class PasswordTest
    {
        [Fact]  
        public void CtorThrowsADomainExceptionWhenCalledWithNullAsArgument()
        {
            Assert.Throws<DomainException>(() => new Password(null));
        }
        
        [Fact]
        public void CtorCreatesAnInstanceWhenCalledWithFilledArgument()
        {
            var password = new Password("minhaSenha");
            
            Assert.IsType<Password>(password);
        }
        
        [Fact]
        public void TheCreatedInstanceHasTheReceivedValue()
        {
            var passwordValue = "minhaSenha";
            var password = new Password(passwordValue);
            
            Assert.Equal(passwordValue, password.Value);
        }
        
        [Theory]
        [InlineData("", false)]
        [InlineData("aa", false)]
        [InlineData("ab", false)]
        [InlineData("AAAbbbCc", false)]
        [InlineData("AbTp9!foo", false)]
        [InlineData("AbTp9!foA", false)]
        [InlineData("AbTp9 fok", false)]
        [InlineData("AbTp9!fok", true)]
        [InlineData("AbTp9!fokzx", true)]
        public void ValidateMethodReturnsTheCorrectResult(string passwordValue, bool expectedValue)
        {
            var password = new Password(passwordValue);

            var isValid = password.Validate();
            
            Assert.Equal(expectedValue, isValid);
        }

        [Fact]
        public void CustomSetOperatorWorks()
        {
            var passwordValue = "minhasenha";
            
            Password password = passwordValue;

            Assert.Equal(passwordValue, password.Value);            
        }
        
        [Fact]
        public void CustomGetOperatorWorks()
        {
            var passwordValue = "minhasenha";
            
            var passwordInstance = new Password(passwordValue);
            string strPassword = passwordInstance;

            Assert.Equal(passwordValue, strPassword);            
        }
        
        [Fact]
        public void ToStringReturnsPasswordValue()
        {
            var passwordValue = "minhasenha";
            
            var passwordInstance = new Password(passwordValue);

            Assert.Equal(passwordValue, passwordInstance.ToString());            
        }
    }
}