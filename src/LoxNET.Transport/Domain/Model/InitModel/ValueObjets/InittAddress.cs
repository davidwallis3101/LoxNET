using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.InitModel.ValueObjects
{
    public class InitAddress : SingleValueObject<string>
    {
        public InitAddress(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid Address '{value}'");
        }
    }
}
