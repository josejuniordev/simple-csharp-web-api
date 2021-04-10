using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SimpleWebApi.Core.DomainObjects.Exceptions;

namespace SimpleWebApi.Core.DomainObjects.ValueObjects
{
    public class Password
    {
        public string Value { get; }

        public Password(string value)
        {
            if (value is null)
                throw new DomainException("A senha não pode ser nula");
            
            Value = value;
        }

        /// <summary>
        /// Valida senha com as regras de domínio
        /// </summary>
        /// <returns>true ou false para os casos de válido ou inválido respectivamente</returns>
        public bool Validate()
        {
            var result = Regex.Match(Value,
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()+-])[A-Za-z\d!@#$%^&*()+-]{9,}$");

            if (!result.Success)
                return result.Success;

            return !HasMultipleOcurrencesOfTheSameChar();
        }

        private bool HasMultipleOcurrencesOfTheSameChar()
        {
            var chars = Value.ToCharArray();
            var hasMultipleCharOccurrence = false;

            foreach (var t in chars)
            {
                hasMultipleCharOccurrence = Value.IndexOf(t) != Value.LastIndexOf(t);

                if (hasMultipleCharOccurrence)
                    break;
            }

            return hasMultipleCharOccurrence;
        }
    }
}