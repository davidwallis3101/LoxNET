using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.InitModel.ValueObjects
{
    public class InitUsername : SingleValueObject<string>
    {
        public InitUsername(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid Username '{value}'");
        }
    }
}
