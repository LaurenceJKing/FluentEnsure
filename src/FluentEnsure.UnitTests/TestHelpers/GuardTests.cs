using System;

namespace FluentEnsure.UnitTests.TestHelpers
{
    public abstract class GuardTests
    {
        public Action Invoking(Action action) => action;
    }
}