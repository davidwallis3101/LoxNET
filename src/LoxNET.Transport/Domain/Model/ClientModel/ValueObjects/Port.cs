using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.ClientModel.ValueObjects
{
    public class Port : SingleValueObject<int>
    {
        public Port(int value) : base(value)
        {
            if (value == 0)
                throw DomainError.With($"Invalid Port '{value}'");
        }
    }
}
