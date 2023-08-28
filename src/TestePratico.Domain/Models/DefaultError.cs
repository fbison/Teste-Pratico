using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TestePratico.Domain.Models
{
    public class DefaultException : Exception
    {
        public DefaultException() : base()
        {
        }

        public DefaultException(string message) : base(message)
        {
        }

        public DefaultException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
