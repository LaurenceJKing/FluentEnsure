using System;

namespace FluentEnsure
{
    public class GuardClauseNotMetException : Exception
    {
        public GuardClauseNotMetException() : base("Guard clause not met.") { }

        public GuardClauseNotMetException(string message) : base(message) { }

        public GuardClauseNotMetException(
            string message,
            (object? value, string name)? candidate,
            Exception? innerException = null) :
            base(message, innerException)
        {
            Name = candidate?.name;
            Value = candidate?.value;
        }

        public object? Value { get; }
        public string? Name { get; }
    }
}