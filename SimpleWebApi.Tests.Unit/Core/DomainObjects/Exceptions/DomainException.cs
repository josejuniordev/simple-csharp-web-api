using System;
using SimpleWebApi.Core.DomainObjects.Exceptions;
using SimpleWebApi.Core.DomainObjects.ValueObjects;
using Xunit;

namespace SimpleWebApi.Tests.Unit.Core.DomainObjects.Exceptions
{
    public class DomainExceptionTest
    {
        [Fact]  
        public void CtorWithoutArgumentsCreatesAnInstance()
        {
            var exception = new DomainException();

            Assert.IsType<DomainException>(exception);
        }
        
        [Fact]  
        public void CtorWithOneArgumentCreatesAnInstance()
        {
            var exception = new DomainException("My Exception");

            Assert.IsType<DomainException>(exception);
        }
        
        [Fact]  
        public void CtorWithTwoArgumentsCreatesAnInstance()
        {
            var exception = new DomainException("My Exception", new DomainException("My Inner Exception"));

            Assert.IsType<DomainException>(exception);
        }
        
        [Fact]  
        public void CtorWithTwoArgumentsCreatesAnInstanceWithAnInnerException()
        {
            var exception = new DomainException("My Exception", new DomainException("My Inner Exception"));

            Assert.IsType<DomainException>(exception.InnerException);
        }
    }
}