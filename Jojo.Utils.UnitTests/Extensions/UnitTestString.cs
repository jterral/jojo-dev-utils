using Jojo.Utils.Extensions.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Jojo.Utils.UnitTests.Extensions
{
    [TestClass]
    public class UnitTestString
    {
        [TestMethod]
        public void Contains()
        {
            Assert.IsTrue("AABBCCDD".Contains("BB", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue("AABBCCDD".Contains("ab", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue("AABBCCDD".Contains("Bc", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsFalse("AABBCCDD".Contains("EE", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
