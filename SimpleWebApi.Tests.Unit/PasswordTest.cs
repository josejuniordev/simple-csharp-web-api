using System;
using SimpleWebApi.Core.DomainObjects.Exceptions;
using SimpleWebApi.Core.DomainObjects.ValueObjects;
using Xunit;

namespace SimpleWebApi.Tests.Unit
{
    public class PasswordTest
    {
        [Fact]  
        public void WhenbuildingTheInstanceThrowsADomainExceptionWhenValueIsEmptyOrNull()
        {
            Assert.Throws<DomainException>(() => new Password(""));
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
    }
}