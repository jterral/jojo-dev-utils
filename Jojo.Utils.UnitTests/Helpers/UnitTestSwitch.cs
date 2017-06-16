using Jojo.Utils.Helpers.Switch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Helpers
{
    [TestClass]
    public class UnitTestSwitch
    {
        [TestMethod]
        public void SwitchOnType_NoException()
        {
            string myString = "MyString";
            var myStringObj = (object)myString;

            TypeSwitch.On(myStringObj)
                .Case<UnitTestSwitch>(x =>
                {
                    Assert.Fail();
                })
                .Case<string>(x =>
                {
                    Assert.IsNotNull(x);
                    Assert.AreEqual(myString, x);
                })
                .Default(x =>
                {
                    Assert.Fail();
                });
        }
    }
}
