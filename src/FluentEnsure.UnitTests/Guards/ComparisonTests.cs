using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentEnsure.Guards;
using FluentEnsure.UnitTests.TestHelpers;
using Xunit;

namespace FluentEnsure.UnitTests.Guards
{
    public class ComparisonTests : GuardTests
    {
        #region IsGreaterThan

        #region IsGreaterThan T 

        [Theory, AutoData]
        public void IsGreaterThan_T_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThan(candidate))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(
                    nameof(candidate).ShouldBeGreaterThan(candidate));

        [Theory, AutoData]
        public void IsGreaterThan_T_fails_when_less_than(List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThan(value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThan(value));
        }

        [Theory, AutoData]
        public void IsGreaterThan_T_succeeds_when_greater_than(List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThan(value))
                .Should().NotThrow();
        }



        #endregion

        #region IsGreaterThan T IComparable 

        [Theory, AutoData]
        public void IsGreaterThan_T_IComparable_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThan(candidate, TestComparer<int>.AlwaysEqual()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThan(candidate));

        [Theory, AutoData]
        public void IsGreaterThan_T_IComparable_fails_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThan(value, TestComparer<int>.AlwaysLess()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThan(value));

        [Theory, AutoData]
        public void IsGreaterThan_T_IComparable_succeeds_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThan(value, TestComparer<int>.AlwaysGreater()))
                .Should().NotThrow();

        #endregion

        #region IsGreaterThan Expression 

        [Theory, AutoData]
        public void IsGreaterThan_Expression_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThan(() => candidate))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThan(nameof(candidate)));

        [Theory, AutoData]
        public void IsGreaterThan_Expression_fails_when_less_than(List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThan(() => value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThan(nameof(value)));
        }

        [Theory, AutoData]
        public void IsGreaterThan_Expression_succeeds_when_greater_than(List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThan(() => value))
                .Should().NotThrow();
        }

        #endregion

        #region IsGreaterThan Expression IComparable 

        [Theory, AutoData]
        public void IsGreaterThan_Expression_IComparable_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThan(() => candidate, TestComparer<int>.AlwaysEqual()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThan(nameof(candidate)));

        [Theory, AutoData]
        public void IsGreaterThan_Expression_IComparable_fails_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThan(() => value, TestComparer<int>.AlwaysLess()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThan(nameof(value)));

        [Theory, AutoData]
        public void IsGreaterThan_Expression_IComparable_succeeds_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThan(() => value, TestComparer<int>.AlwaysGreater()))
                .Should().NotThrow();

        #endregion

        #endregion

        #region IsGreaterThanOrEqualTo

        #region IsGreaterThanOrEqualTo T 

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_T_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThanOrEqualTo(candidate))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_T_fails_when_less_than(List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThanOrEqualTo(value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThanOrEqualTo(value));
        }

        [Theory, AutoData]
        public void IsGreaterThanThanOrEqualTo_T_succeeds_when_greater_than(
            List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThanOrEqualTo(value))
                .Should().NotThrow();
        }



        #endregion

        #region IsGreaterThanOrEqualTo T IComparable 

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_T_IComparable_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThanOrEqualTo(candidate, TestComparer<int>.AlwaysEqual()))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_T_IComparable_fails_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThanOrEqualTo(value, TestComparer<int>.AlwaysLess()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThanOrEqualTo(value));

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_T_IComparable_succeeds_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThan(value, TestComparer<int>.AlwaysGreater()))
                .Should().NotThrow();

        #endregion

        #region IsGreaterThanOrEqualTo Expression 

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_Expression_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThanOrEqualTo(() => candidate))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_Expression_fails_when_less_than(List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThanOrEqualTo(() => value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThanOrEqualTo(nameof(value)));
        }

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_Expression_succeeds_when_greater_than(List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsGreaterThanOrEqualTo(() => value))
                .Should().NotThrow();
        }

        #endregion

        #region IsGreaterThanOrEqualTo Expression IComparable 

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_Expression_IComparable_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThanOrEqualTo(() => candidate, TestComparer<int>.AlwaysEqual()))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_Expression_IComparable_fails_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThanOrEqualTo(() => value, TestComparer<int>.AlwaysLess()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeGreaterThanOrEqualTo(nameof(value)));

        [Theory, AutoData]
        public void IsGreaterThanOrEqualTo_Expression_IComparable_succeeds_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsGreaterThanOrEqualTo(() => value, TestComparer<int>.AlwaysGreater()))
                .Should().NotThrow();

        #endregion

        #endregion

        #region IsLessThan

        #region IsLessThan T 

        [Theory, AutoData]
        public void IsLessThan_T_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThan(candidate))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(
                    nameof(candidate).ShouldBeLessThan(candidate));

        [Theory, AutoData]
        public void IsLessThan_T_fails_when_greater_than(List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThan(value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThan(value));
        }

        [Theory, AutoData]
        public void IsLessThan_T_succeeds_when_less_than(List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThan(value))
                .Should().NotThrow();
        }

        #endregion

        #region IsLessThan T IComparable 

        [Theory, AutoData]
        public void IsLessThan_T_IComparable_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThan(candidate, TestComparer<int>.AlwaysEqual()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThan(candidate));

        [Theory, AutoData]
        public void IsLessThan_T_IComparable_fails_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThan(value, TestComparer<int>.AlwaysGreater()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThan(value));

        [Theory, AutoData]
        public void IsLessThan_T_IComparable_succeeds_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThan(value, TestComparer<int>.AlwaysLess()))
                .Should().NotThrow();

        #endregion

        #region IsLessThan Expression 

        [Theory, AutoData]
        public void IsLessThan_Expression_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThan(() => candidate))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThan(nameof(candidate)));

        [Theory, AutoData]
        public void IsLessThan_Expression_fails_when_greater_than(List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThan(() => value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThan(nameof(value)));
        }

        [Theory, AutoData]
        public void IsLessThan_Expression_succeeds_when_less_than(List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThan(() => value))
                .Should().NotThrow();
        }

        #endregion

        #region IsLessThan Expression IComparable 

        [Theory, AutoData]
        public void IsLessThan_Expression_IComparable_fails_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThan(() => candidate, TestComparer<int>.AlwaysEqual()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThan(nameof(candidate)));

        [Theory, AutoData]
        public void IsLessThan_Expression_IComparable_fails_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThan(() => value, TestComparer<int>.AlwaysGreater()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThan(nameof(value)));

        [Theory, AutoData]
        public void IsLessThan_Expression_IComparable_succeeds_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThan(() => value, TestComparer<int>.AlwaysLess()))
                .Should().NotThrow();

        #endregion

        #endregion

        #region IsLessThanOrEqualTo

        #region IsLessThanOrEqualTo T 

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_T_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThanOrEqualTo(candidate))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_T_fails_when_greater_than(List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThanOrEqualTo(value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThanOrEqualTo(value));
        }

        [Theory, AutoData]
        public void IsLessThanThanOrEqualTo_T_succeeds_when_less_than(
            List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThanOrEqualTo(value))
                .Should().NotThrow();
        }



        #endregion

        #region IsLessThanOrEqualTo T IComparable 

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_T_IComparable_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThanOrEqualTo(candidate, TestComparer<int>.AlwaysEqual()))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_T_IComparable_fails_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThanOrEqualTo(value, TestComparer<int>.AlwaysGreater()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThanOrEqualTo(value));

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_T_IComparable_succeeds_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThan(value, TestComparer<int>.AlwaysLess()))
                .Should().NotThrow();

        #endregion

        #region IsLessThanOrEqualTo Expression 

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_Expression_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThanOrEqualTo(() => candidate))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_Expression_fails_when_greater_than(List<int> values)
        {
            var candidate = values.Max();
            var value = values.Min();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThanOrEqualTo(() => value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThanOrEqualTo(nameof(value)));
        }

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_Expression_succeeds_when_less_than(List<int> values)
        {
            var candidate = values.Min();
            var value = values.Max();
            Invoking(() =>
                    Ensure.That(() => candidate).IsLessThanOrEqualTo(() => value))
                .Should().NotThrow();
        }

        #endregion

        #region IsLessThanOrEqualTo Expression IComparable 

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_Expression_IComparable_succeeds_when_equal(int candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThanOrEqualTo(() => candidate, TestComparer<int>.AlwaysEqual()))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_Expression_IComparable_fails_when_greater_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThanOrEqualTo(() => value, TestComparer<int>.AlwaysGreater()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeLessThanOrEqualTo(nameof(value)));

        [Theory, AutoData]
        public void IsLessThanOrEqualTo_Expression_IComparable_succeeds_when_less_than(
            int candidate,
            int value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsLessThanOrEqualTo(() => value, TestComparer<int>.AlwaysLess()))
                .Should().NotThrow();

        #endregion

        #endregion

        private class TestComparer<T> : IComparer<T>
        {
            private readonly Func<T, T, int> _compare;

            private TestComparer(Func<T, T, int> compare)
            {
                _compare = compare;
            }

            public int Compare(T x, T y) => _compare(x, y);

            public static TestComparer<T> AlwaysGreater() =>
                new TestComparer<T>((_, __) => 1);

            public static TestComparer<T> AlwaysEqual() =>
                new TestComparer<T>((_, __) => 0);

            public static TestComparer<T> AlwaysLess() =>
                new TestComparer<T>((_, __) => -1);
        }
    }
}