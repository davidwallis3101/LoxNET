using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.ClientModel.ValueObjects
{
    public class HostPublicKey : SingleValueObject<string>
    {
        public HostPublicKey(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid PublicKey '{value}'");
        }
    }
}
