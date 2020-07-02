using System;

namespace FluentEnsure
{
    public readonly struct Candidate<T>
    {
        public Candidate(T value, string name)
        {
            Value = value;
            Name = name;
        }

        public T Value { get; }
        public string Name { get; }

        public Candidate<T> MeetsCondition(
            Func<T, bool> condition,
            Configure<T> configure)
        {
            if (condition(Value)) return this;
            throw configure(new ExceptionConfiguration<T>()).Raise(this);
        }
    }
}