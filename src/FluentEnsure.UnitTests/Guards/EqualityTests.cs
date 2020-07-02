using System;
using System.Collections.Generic;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentEnsure.Guards;
using FluentEnsure.UnitTests.TestHelpers;
using Xunit;

namespace FluentEnsure.UnitTests.Guards
{
    public class EqualityTests : GuardTests
    {
        #region IsEqualTo

        #region  IsEqualTo T Func<T,T,bool>

        [Theory, AutoData]
        public void IsEqualTo_T_Func_fails_when_not_equal(
            string candidate,
            string value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsEqualTo(value, (_, __) => false))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldEqual(value));

        [Theory, AutoData]
        public void IsEqualTo_T_Func_succeeds_when_equal(
            string candidate,
            string value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsEqualTo(value, (_, __) => true))
                .Should().NotThrow();
        #endregion

        #region IsEqualTo Expression<Func<T>> Func<T,T,bool>

        [Theory, AutoData]
        public void IsEqualTo_Expression_Func_fails_when_not_equal(
            string candidate,
            string value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsEqualTo(() => value, (_, __) => false))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldEqual(nameof(value)));

        [Theory, AutoData]
        public void IsEqualTo_Expression_Func_succeeds_when_equal(
            string candidate,
            string value) =>
            Invoking(() =>
                    Ensure.That(() => candidate)
                        .IsEqualTo(() => value, (_, __) => true))
                .Should().NotThrow();
        #endregion

        #region IsEqualTo T

        [Theory, AutoData]
        public void IsEqualTo_T_fails_when_T_is_null(string candidate) =>
            Invoking(() => Ensure.That(() => candidate)
                    .IsEqualTo((string)null))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldEqual("null"));

        [Theory, AutoData]
        public void IsEqualTo_T_fails_when_GuardClause_Value_is_null(
            string value) =>
            Invoking(() => Ensure.That(() => (string)null)
                    .IsEqualTo(value))
                .Should().Throw<NullReferenceException>();

        [Theory, AutoData]
        public void IsEqualTo_T_fails_when_not_equal(
            string candidate,
            string value) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsEqualTo(value))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldEqual(value));

        [Theory, AutoData]
        public void IsEqualTo_T_succeeds_when_equal(string candidate) =>
            Invoking(() => Ensure.That(() => candidate).IsEqualTo(candidate))
                .Should().NotThrow();

        #endregion

        #region IsEqualTo Expression<Func<T>>

        [Theory, AutoData]
        public void IsEqualTo_Expression_fails_when_T_is_null(string candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsEqualTo(() => null))
                .Should().Throw<NullReferenceException>();

        [Theory, AutoData]
        public void IsEqualTo_Expression_fails_when_GuardClause_Value_is_null(
            string value) =>
                Invoking(() =>
                    Ensure.That(() => (string)null).IsEqualTo(() => value))
                .Should().Throw<NullReferenceException>();

        [Theory, AutoData]
        public void IsEqualTo_Expression_fails_when_not_equal(
            string candidate,
            string value) =>
                Invoking(() =>
                        Ensure.That(() => candidate).IsEqualTo(() => value))
                    .Should().Throw<GuardClauseNotMetException>()
                    .WithMessage(nameof(candidate).ShouldEqual(nameof(value)));

        [Theory, AutoData]
        public void IsEqualTo_Expression_succeeds_when_equal(string candidate) =>
            Invoking(() =>
                Ensure.That(() => candidate).IsEqualTo(() => candidate))
                .Should().NotThrow();

        #endregion

        #region IsEqualTo T IEqualityComparer<T>


        [Theory, AutoData]
        public void IsEqualTo_T_IEqualityComparer_fails_when_not_equal(
            string candidate,
            string value) =>
                Invoking(() => Ensure.That(() => candidate).IsEqualTo(
                    value,
                    TestEqualityComparer<string>.NeverEqual()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldEqual(value));

        [Theory, AutoData]
        public void IsEqualTo_T_IEqualityComparer_succeeds_when_equal(
            string candidate, 
            string value) =>
                Invoking(() => Ensure.That(() => candidate).IsEqualTo(
                    value,
                    TestEqualityComparer<string>.AlwaysEqual()))
                    .Should().NotThrow();
        #endregion

        #region IsEqualTo Expression<Func<T>> IEqualityComparer<T>

        [Theory, AutoData]
        public void IsEqualTo_Expression_IEqualityComparer_fails_when_not_equal(
            string candidate,
            string value) =>
                Invoking(() => Ensure.That(() => candidate).IsEqualTo(
                        () => value,
                        TestEqualityComparer<string>.NeverEqual()))
                    .Should().Throw<GuardClauseNotMetException>()
                    .WithMessage(nameof(candidate).ShouldEqual(nameof(value)));

        [Theory, AutoData]
        public void IsEqualTo_Expression_IEqualityComparer_succeeds_when_equal(
            string candidate,
            string value) =>
                Invoking(() =>
                    Ensure.That(() => candidate).IsEqualTo(
                        () => value,
                        TestEqualityComparer<string>.AlwaysEqual()))
                    .Should().NotThrow();

        #endregion

        #endregion

        #region IsNotEqualTo

        #region  IsNotEqualTo T Func<T,T,bool>

        [Theory, AutoData]
        public void IsNotEqualTo_T_Func_fails_when_equal(
            string candidate,
            string value) =>
                Invoking(() =>
                    Ensure.That(() => candidate).IsNotEqualTo(
                        value,
                        (_, __) => true))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldNotEqual(value));

        [Theory, AutoData]
        public void IsNotEqualTo_T_Func_succeeds_when_not_equal(
            string candidate,
            string value) =>
                Invoking(() => Ensure.That(() => candidate).IsNotEqualTo(
                        value,
                        (_, __) => false))
                    .Should().NotThrow();
        #endregion

        #region IsNotEqualTo Expression<Func<T>> Func<T,T,bool>

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_Func_succeeds_when_not_equal(
            string candidate, 
            string value) =>
                Invoking(() =>
                    Ensure.That(() => candidate).IsNotEqualTo(
                        () => value,
                        (_, __) => false))
                    .Should().NotThrow();

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_Func_fails_when_equal(string candidate) =>
               Invoking(() =>
                   Ensure.That(() => candidate).IsNotEqualTo(
                       () => candidate,
                       (_, __) => true))
               .Should().Throw<GuardClauseNotMetException>()
               .WithMessage(nameof(candidate).ShouldNotEqual(nameof(candidate)));

        #endregion

        #region IsNotEqualTo T

        [Theory, AutoData]
        public void IsNotEqualTo_T_succeeds_when_T_is_null(string candidate) =>
                Invoking(() => Ensure.That(() => candidate).IsNotEqualTo((string)null))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsNotEqualTo_T_fails_when_GuardClause_Value_is_null(
            string value) =>
                Invoking(() => Ensure.That(() => (string)null).IsNotEqualTo(value))
                    .Should().Throw<NullReferenceException>();

        [Theory, AutoData]
        public void IsNotEqualTo_T_fails_when_equal(string candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsNotEqualTo(candidate))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldNotEqual(candidate));

        [Theory, AutoData]
        public void IsNotEqualTo_T_succeeds_when_not_equal(
            string candidate,
            string value) =>
            Invoking(() =>
                Ensure.That(() => candidate).IsNotEqualTo(value))
                .Should().NotThrow();

        #endregion

        #region IsNotEqualTo Expression<Func<T>>

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_fails_when_T_is_null(
            string candidate) =>
                Invoking(() => Ensure.That(() => candidate).IsNotEqualTo(() => null))
                .Should().Throw<NullReferenceException>();

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_fails_when_GuardClause_Value_is_null(
            string value) =>
                Invoking(() => Ensure.That(() => (string)null).IsNotEqualTo(() => value))
                    .Should().Throw<NullReferenceException>();

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_succeeds_when_not_equal(
            string candidate,
            string value) =>
            Invoking(() => 
                Ensure.That(() => candidate).IsNotEqualTo(() => value))
                .Should().NotThrow();

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_fails_when_equal(string candidate) =>
                Invoking(() =>
                        Ensure.That(() => candidate).IsNotEqualTo(() => candidate))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldNotEqual(nameof(candidate)));

        #endregion

        #region IsNotEqualTo T IEqualityComparer<T>

        [Theory, AutoData]
        public void IsNotEqualTo_T_IEqualityComparer_succeeds_when_not_equal(
            string candidate, 
            string value) =>
            Invoking(() => 
                Ensure.That(() => candidate).IsNotEqualTo(value, TestEqualityComparer<string>.NeverEqual()))
                .Should().NotThrow();


        [Theory, AutoData]
        public void IsNotEqualTo_T_IEqualityComparer_fails_when_equal(
            string candidate,
            string value) =>
                Invoking(() =>
                    Ensure.That(() => candidate).IsNotEqualTo(
                        value,
                        TestEqualityComparer<string>.AlwaysEqual()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldNotEqual(value));

        #endregion

        #region IsNotEqualTo Expression<Func<T>> IEqualityComparer<T>

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_IEqualityComparer_succeeds_when_not_equal(
            string candidate,
            string value) =>
                Invoking(() => Ensure.That(() => candidate).IsNotEqualTo(
                    () => value,
                    TestEqualityComparer<string>.NeverEqual()))
                    .Should().NotThrow();

        [Theory, AutoData]
        public void IsNotEqualTo_Expression_IEqualityComparer_fails_when_equal(
            string candidate,
            string value) =>
                Invoking(() =>
                    Ensure.That(() => candidate).IsNotEqualTo(
                        () => value,
                        TestEqualityComparer<string>.AlwaysEqual()))
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldNotEqual(nameof(value)));

        #endregion

        #endregion

        #region IsNull

        [Theory, AutoData]
        public void IsNull_fails_when_not_null(string candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsNull())
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldBeNull());

        [Fact]
        public void IsNull_succeeds_when_null()
        {
            string candidate = null;
            Invoking(() =>
                    Ensure.That(() => candidate).IsNull())
                .Should().NotThrow();
        }

        #endregion

        #region IsNotNull

        [Theory, AutoData]
        public void IsNotNull_succeeds_when_not_null(string candidate) =>
            Invoking(() =>
                    Ensure.That(() => candidate).IsNotNull())
                .Should().NotThrow();

        [Fact]
        public void IsNotNull_fails_when_null()
        {
            string candidate = null;

            Invoking(() =>
                    Ensure.That(() => candidate).IsNotNull())
                .Should().Throw<GuardClauseNotMetException>()
                .WithMessage(nameof(candidate).ShouldNotBeNull());
        }


        #endregion

        private class TestEqualityComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _equals;

            private TestEqualityComparer(Func<T, T, bool> equals)
            {
                _equals = equals;
            }

            public bool Equals(T x, T y) => _equals(x, y);

            public int GetHashCode(T obj) => obj.GetHashCode();

            public static TestEqualityComparer<T> AlwaysEqual() =>
                new TestEqualityComparer<T>((_, __) => true);

            public static TestEqualityComparer<T> NeverEqual() =>
                new TestEqualityComparer<T>((_, __) => false);
        }
    }
}
