using Blacksmith.Validations.Exceptions;
using System;

namespace SharedShopping.Domain.Exceptions
{
    [Serializable]
    public class RequiredUserName : DomainException
    {
    }
}