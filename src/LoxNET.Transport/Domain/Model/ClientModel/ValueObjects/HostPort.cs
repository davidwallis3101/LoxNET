using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.ClientModel.ValueObjects
{
    public class HostPort : SingleValueObject<int>
    {
        public HostPort(int value) : base(value)
        {
            if (value == 0)
                throw DomainError.With($"Invalid HostPort '{value}'");
        }
    }
}
