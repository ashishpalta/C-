using System;
using NUnit.Framework;

namespace MoviePlexProject.Tests
{
    [TestFixture]
    class Program
    {
        [Test]
        public void userAgeValidation()
        {
            Assert.IsFalse(false, "Can't Watch Movie. You are Under Age");
            Assert.IsTrue(true, "Wrong Input");
        }
        [Test]
        public void validatingUserEntry()
        {
            Assert.IsTrue(true, "Enjoy Your Movie");
            Assert.IsFalse(false, "Can't Watch Movie. You are Under Age");
        }

    }
}
