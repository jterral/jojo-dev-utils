﻿using Jojo.Utils.Helpers.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Jojo.Common.UnitTest.Helpers
{
    [TestClass]
    public class UnitTestException
    {
        [TestMethod]
        public void GetMessageException()
        {
            string messageException = "MESSAGE EXCEPTION";
            try
            {
                throw new Exception(messageException);
            }
            catch (Exception e)
            {
                string message = ExceptionHelper.GetMessageException(e);
                Assert.IsFalse(string.IsNullOrEmpty(message));
                Assert.IsTrue(message.Contains(messageException));
                Assert.IsTrue(message.Contains("<StackTrace>"));
                Assert.IsTrue(message.Contains("</StackTrace>"));

                message = ExceptionHelper.GetMessageException(e, false);
                Assert.IsFalse(string.IsNullOrEmpty(message));
                Assert.IsFalse(message.Contains("StackTrace"));
                Assert.AreEqual(messageException, message);
            }
        }
    }
}
