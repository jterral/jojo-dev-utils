using Jojo.Utils.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Utils.UnitTests.Patterns
{
    [TestClass]
    public class UnitTestSingleton
    {
        [TestMethod]
        public void CreateSingleton()
        {
            Assert.IsNotNull(Singleton.Instance);
        }
    }
}
