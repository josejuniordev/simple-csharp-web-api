using System;
using System.ComponentModel.DataAnnotations;
using SimpleWebApi.Core.DomainObjects.Exceptions;

namespace SimpleWebApi.Core.DomainObjects.ValueObjects
{
    public class Password
    {
        public string Value { get; }

        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("A senha não pode ser vazia");
            
            Value = value;
        }

        public bool Validate()
        {
            return false;
        }
    }
}