using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.ClientModel.ValueObjects
{
    public class HostPassword : SingleValueObject<string>
    {
        public HostPassword(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid Password '{value}'");
        }
    }
}
