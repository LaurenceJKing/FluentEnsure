using System;
using System.Linq.Expressions;

namespace FluentEnsure
{
    public static class Ensure
    {
        public static Candidate<T> That<T>(
            Expression<Func<T>> candidate) =>
        new Candidate<T>(
            candidate.Compile().Invoke(),
            candidate.FullName());

        public static Candidate<T> That<T>(T value, string name) =>
            new Candidate<T>(value, name);
    }
}