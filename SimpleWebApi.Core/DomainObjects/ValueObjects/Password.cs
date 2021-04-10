using System;
using System.ComponentModel.DataAnnotations;
using SimpleWebApi.Core.DomainObjects.Exceptions;

namespace SimpleWebApi.Core.DomainObjects.ValueObjects
{
    public class Password
    {
        private string _value;

        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("A senha não pode ser vazia");
            
            _value = value;
        }

        public bool IsValid()
        {
            return false;
        }
    }
}