using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentEnsure.UnitTests.TestHelpers;
using Xunit;

namespace FluentEnsure.UnitTests
{
    public class ExpressionHelperTests
    {
        [Theory, AutoData]
        public void Expression_Func_T_FullName_is_correct(Person person)
        {
            Expression<Func<int>> expression = () => person.Age;
            expression.FullName().Should().Be("person.Age");
        }

        [Fact]
        public void Expression_Func_T_TMember_FullName_is_correct()
        {
            Expression<Func<Person, int>> expression = person => person.Age;
            expression.FullName().Should().Be("Age");
        }
    }
}
