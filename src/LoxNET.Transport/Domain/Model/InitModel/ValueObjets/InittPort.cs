using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.InitModel.ValueObjects
{
    public class InitPort : SingleValueObject<int>
    {
        public InitPort(int value) : base(value)
        {
            if (value == 0)
                throw DomainError.With($"Invalid Port '{value}'");
        }
    }
}
