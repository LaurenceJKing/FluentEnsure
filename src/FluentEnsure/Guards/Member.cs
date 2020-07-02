using System;
using System.Linq.Expressions;

namespace FluentEnsure.Guards
{
    public static partial class Guard
    {
        public static Candidate<T> Member<T, TMember>(
            this Candidate<T> candidate,
            Expression<Func<T, TMember>> selectMember,
            Action<Candidate<TMember>> guard)
        {
            guard(
                new Candidate<TMember>(
                    selectMember.Compile().Invoke(candidate.Value),
                    candidate.Name + "." + selectMember.FullName()));

            return candidate;
        }
    }
}
