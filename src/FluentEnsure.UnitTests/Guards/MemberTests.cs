using AutoFixture.Xunit2;
using FluentAssertions;
using FluentEnsure.Guards;
using FluentEnsure.UnitTests.TestHelpers;
using Xunit;

namespace FluentEnsure.UnitTests.Guards
{
    public class MemberTests: GuardTests
    {
        [Theory, AutoData]
        public void Member_should_fail_when_ensure_fails(Person person) =>
            Invoking(() => Ensure.That(() => person)
                    .Member(p => p.Age, age => age.MeetsCondition(
                        _ => false, 
                        err => err.Message((i,n) => n))))
                .Should().Throw<GuardClauseNotMetException>().WithMessage(
                    $"{nameof(person)}.{nameof(person.Age)}");

        [Theory, AutoData]
        public void Member_should_fail_when_ensure_succeeds(Person person) =>
            Invoking(() => Ensure.That(() => person)
                    .Member(p => p.Age, age => age.MeetsCondition(
                        _ => true,
                        err => err)))
                .Should().NotThrow();
    }
}
