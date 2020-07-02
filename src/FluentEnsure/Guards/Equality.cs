using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentEnsure.Guards
{
    public static partial class Guard
    {
        #region IsEqualTo
        public static Candidate<T> IsEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Func<T, T, bool> equals,
            Configure<T>? configure = null) =>
            candidate.MeetsCondition(
                c => equals(c, selector.Compile().Invoke()),
                configure.Default(
                    candidate.Name.ShouldEqual(selector.FullName()),
                    (selector.FullName(), selector.Compile().Invoke())));

        public static Candidate<T> IsEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            IEqualityComparer<T> equalityComparer,
            Configure<T>? configure = null) =>
            candidate.IsEqualTo(
                selector,
                equalityComparer.Equals,
                configure);

        public static Candidate<T> IsEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Configure<T>? configure = null) =>
            candidate.IsEqualTo(
                selector,
                EqualityComparer<T>.Default,
                configure);

        public static Candidate<T> IsEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            Func<T, T, bool> equals,
            Configure<T>? configure = null) =>
            candidate.MeetsCondition(
                c => equals(c, value),
                configure.Default(
                    candidate.Name.ShouldEqual(value)));

        public static Candidate<T> IsEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            IEqualityComparer<T> equalityComparer,
            Configure<T>? configure = null) =>
            candidate.IsEqualTo(
                value,
                equalityComparer.Equals,
                configure);

        public static Candidate<T> IsEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            Configure<T>? configure = null) =>
            candidate.IsEqualTo(
                value,
                EqualityComparer<T>.Default,
                configure);

        #endregion

        #region IsNotEqualTo
        public static Candidate<T> IsNotEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Func<T, T, bool> equals,
            Configure<T>? configure = null) =>
            candidate.MeetsCondition(
                c => !equals(c, selector.Compile().Invoke()),
                configure.Default(
                    candidate.Name.ShouldNotEqual(selector.FullName()),
                    (selector.FullName(), selector.Compile().Invoke())));

        public static Candidate<T> IsNotEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            IEqualityComparer<T> equalityComparer,
            Configure<T>? configure = null) =>
            candidate.IsNotEqualTo(
                selector,
                equalityComparer.Equals,
                configure);

        public static Candidate<T> IsNotEqualTo<T>(
            this Candidate<T> candidate,
            Expression<Func<T>> selector,
            Configure<T>? configure = null) =>
            candidate.IsNotEqualTo(
                selector,
                EqualityComparer<T>.Default,
                configure);

        public static Candidate<T> IsNotEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            Func<T, T, bool> equals,
            Configure<T>? configure = null) =>
            candidate.MeetsCondition(
                c => !equals(c, value),
                configure.Default(
                    candidate.Name.ShouldNotEqual(value)));

        public static Candidate<T> IsNotEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            IEqualityComparer<T> equalityComparer,
            Configure<T>? configure = null) =>
            candidate.IsNotEqualTo(
                value,
                equalityComparer.Equals,
                configure);

        public static Candidate<T> IsNotEqualTo<T>(
            this Candidate<T> candidate,
            T value,
            Configure<T>? configure = null) =>
            candidate.IsNotEqualTo(
                value,
                EqualityComparer<T>.Default,
                configure);
        #endregion

        #region IsNull

        public static Candidate<T> IsNull<T>(
            this Candidate<T> candidate,
            Configure<T>? configure = null) =>
            candidate.MeetsCondition(value => value is null,
                configure.Default(
                    candidate.Name.ShouldBeNull()));

        public static Candidate<T> IsNotNull<T>(
            this Candidate<T> candidate,
            Configure<T>? configure = null) =>
            candidate.MeetsCondition(value => !(value is null),
                configure.Default(
                    candidate.Name.ShouldNotBeNull()));


        #endregion

        internal static string ShouldBeNull(this string name) =>
            $"{name} should be null.";

        internal static string ShouldNotBeNull(this string name) =>
            $"{name} should not be null.";

        internal static string ShouldEqual(this string name, object? value) =>
            $"{name} should equal {value ?? "null"}.";

        internal static string ShouldNotEqual(this string name, object? value) =>
            $"{name} should not equal {value ?? "null"}.";
    }
}
