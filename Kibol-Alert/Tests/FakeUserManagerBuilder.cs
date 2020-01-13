using Moq;
using System;

namespace Kibol_Alert.Tests
{
    public class FakeUserManagerBuilder
    {
        private Mock<FakeUserManager> _mock = new Mock<FakeUserManager>();

        public FakeUserManagerBuilder With(Action<Mock<FakeUserManager>> mock)
        {
            mock(_mock);
            return this;
        }
        public Mock<FakeUserManager> Build()
        {
            return _mock;
        }
    }
    public class FakeSignInManagerBuilder
    {
        private Mock<FakeSignInManager> _mock = new Mock<FakeSignInManager>();

        public FakeSignInManagerBuilder With(Action<Mock<FakeSignInManager>> mock)
        {
            mock(_mock);
            return this;
        }
        public Mock<FakeSignInManager> Build()
        {
            return _mock;
        }
    }
}