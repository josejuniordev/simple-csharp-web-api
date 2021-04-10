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
    }
}