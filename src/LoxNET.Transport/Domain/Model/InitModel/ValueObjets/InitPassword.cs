using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.InitModel.ValueObjects
{
    public class InitPassword : SingleValueObject<string>
    {
        public InitPassword(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid Password '{value}'");
        }
    }
}
