using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentEnsure.Guards
{
    public static partial class Guard
    {
        #region IsGreaterThan

        public static Candidate<T> IsGreaterThan<T>(
            this Candidate<T> candidate,
            T value,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, value) > 0,
                configure.Default(
                    candidate.Name.ShouldBeGreaterThan(value)));

        public static Candidate<T> IsGreaterThan<T>(
            this Candidate<T> candidate,
            T value,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsGreaterThan(
                value,
                Comparer<T>.Default,
                configure);

        public static Candidate<T> IsGreaterThan<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, selector.Compile().Invoke()) > 0,
                configure.Default(
                    candidate.Name.ShouldBeGreaterThan(selector.FullName()),
                    (selector.FullName(), selector.Compile().Invoke())));

        public static Candidate<T> IsGreaterThan<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsGreaterThan(
                selector,
                Comparer<T>.Default,
                configure);

        #endregion

        #region IsGreaterThanOrEqualTo

        public static Candidate<T> IsGreaterThanOrEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, value) >= 0,
                configure.Default(
                    candidate.Name.ShouldBeGreaterThanOrEqualTo(value)));

        public static Candidate<T> IsGreaterThanOrEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsGreaterThanOrEqualTo(
                value,
                Comparer<T>.Default,
                configure);

        public static Candidate<T> IsGreaterThanOrEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, selector.Compile().Invoke()) >= 0,
                configure.Default(
                    candidate.Name.ShouldBeGreaterThanOrEqualTo(selector.FullName()),
                    (selector.FullName(), selector.Compile().Invoke())));

        public static Candidate<T> IsGreaterThanOrEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsGreaterThanOrEqualTo(
                selector,
                Comparer<T>.Default,
                configure);

        #endregion

        #region IsLessThan

        public static Candidate<T> IsLessThan<T>(
            this Candidate<T> candidate,
            T value,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, value) < 0,
                configure.Default(
                    $"{candidate.Name} should be less than {value}."));

        public static Candidate<T> IsLessThan<T>(
            this Candidate<T> candidate,
            T value,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsLessThan(
                value,
                Comparer<T>.Default,
                configure);

        public static Candidate<T> IsLessThan<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, selector.Compile().Invoke()) < 0,
                configure.Default(
                    $"{candidate.Name} should be less than {selector.FullName()}.",
                    (selector.FullName(), selector.Compile().Invoke())));

        public static Candidate<T> IsLessThan<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsLessThan(
                selector,
                Comparer<T>.Default,
                configure);

        #endregion

        #region IsLessThanOrEqualTo

        public static Candidate<T> IsLessThanOrEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, value) <= 0,
                configure.Default(
                    $"{candidate.Name} should be less than or equal to {value}."));

        public static Candidate<T> IsLessThanOrEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsLessThanOrEqualTo(
                value,
                Comparer<T>.Default,
                configure);

        public static Candidate<T> IsLessThanOrEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            IComparer<T> comparer,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.MeetsCondition(
                c => comparer.Compare(c, selector.Compile().Invoke()) <= 0,
                configure.Default(
                    $"{candidate.Name} should be less than or equal to {selector.FullName()}.",
                    (selector.FullName(), selector.Compile().Invoke())));

        public static Candidate<T> IsLessThanOrEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Configure<T>? configure = null)
            where T : IComparable =>
            candidate.IsLessThanOrEqualTo(
                selector,
                Comparer<T>.Default,
                configure);

        #endregion

        internal static string ShouldBeGreaterThan(this string name, object value) =>
            $"{name} should be greater than {value}.";

        internal static string ShouldBeGreaterThanOrEqualTo(
            this string name,
            object value) =>
            $"{name} should be greater than or equal to {value}.";

        internal static string ShouldBeLessThan(this string name, object value) =>
            $"{name} should be less than {value}.";

        internal static string ShouldBeLessThanOrEqualTo(
            this string name,
            object value) =>
            $"{name} should be less than or equal to {value}.";
    }
}