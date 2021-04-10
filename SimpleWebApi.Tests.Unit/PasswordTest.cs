using System;
using SimpleWebApi.Core.DomainObjects.Exceptions;
using SimpleWebApi.Core.DomainObjects.ValueObjects;
using Xunit;

namespace SimpleWebApi.Tests.Unit
{
    public class PasswordTest
    {
        [Fact]  
        public void WhenbuildingTheInstanceThrowsADomainExceptionWhenValueIsNull()
        {
            Assert.Throws<DomainException>(() => new Password(null));
        }
        
        [Fact]
        public void WhenbuildingTheInstanceDontThrowsADomainExceptionWhenValueIsFilled()
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
    }
}