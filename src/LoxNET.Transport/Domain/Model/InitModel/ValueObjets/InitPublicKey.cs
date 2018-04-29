using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.InitModel.ValueObjects
{
    public class InitPublicKey : SingleValueObject<string>
    {
        public InitPublicKey(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid PublicKey '{value}'");
        }
    }
}
