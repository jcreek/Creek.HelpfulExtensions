using NUnit.Framework;
using Creek.HelpfulExtensions;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    public class ExceptionExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturnBaseExceptionMessage()
        {
            try
            {
                // This function calls another that forces a
                // division by 0.
                Rethrow();
            }
            catch (Exception ex)
            {
                string baseExceptionMessage = ex.BaseExceptionMessage();
                Assert.AreEqual("Attempted to divide by zero.", baseExceptionMessage);
            }
        }

        [Test]
        public void ShouldReturnBaseExceptionMessageAndStackTrace()
        {
            try
            {
                // This function calls another that forces a
                // division by 0.
                Rethrow();
            }
            catch (Exception ex)
            {
                string baseExceptionMessageAndStackTrace = ex.BaseExceptionMessageAndStackTrace();
                StringAssert.StartsWith("Attempted to divide by zero.", baseExceptionMessageAndStackTrace);
                Assert.AreNotEqual("Attempted to divide by zero.", baseExceptionMessageAndStackTrace);
            }
        }

        [Test]
        public void ShouldReturnAllInnerExceptionMessages()
        {
            try
            {
                // This function calls another that forces a
                // division by 0.
                Rethrow();
            }
            catch (Exception ex)
            {
                List<string> allInnerExceptionMessages = ex.AllInnerExceptionMessages();

                List<string> expected = new List<string>()
                {
                    "Caught the second exception and threw a third in response.",
                    "Forced a division by 0 and threw a second exception.",
                    "Attempted to divide by zero.",
                };

                CollectionAssert.AreEqual(expected, allInnerExceptionMessages);
            }
        }

        [Test]
        public void ShouldReturnAllInnerExceptionMessagesAndStackTraces()
        {
            try
            {
                // This function calls another that forces a
                // division by 0.
                Rethrow();
            }
            catch (Exception ex)
            {
                List<string> allInnerExceptionMessagesAndStackTraces = ex.AllInnerExceptionMessagesAndStackTraces();

                List<string> expected = new List<string>()
                {
                    "Caught the second exception and threw a third in response.",
                    "Forced a division by 0 and threw a second exception.",
                    "Attempted to divide by zero.",
                };

                foreach (var (baseExceptionMessageAndStackTrace, index) in allInnerExceptionMessagesAndStackTraces.WithIndex())
                {
                    StringAssert.StartsWith(expected[index], baseExceptionMessageAndStackTrace);
                    Assert.AreNotEqual(expected[index], baseExceptionMessageAndStackTrace);
                }
            }
        }

        // This function catches the exception from the called
        // function DivideBy0( ) and throws another in response.
        private void Rethrow()
        {
            try
            {
                DivideBy0();
            }
            catch (Exception ex)
            {
                throw new ThirdLevelException("Caught the second exception and threw a third in response.", ex);
            }
        }

        // This function forces a division by 0 and throws a second
        // exception.
        private void DivideBy0()
        {
            try
            {
                int zero = 0;
                int ecks = 1 / zero;
            }
            catch (Exception ex)
            {
                throw new SecondLevelException("Forced a division by 0 and threw a second exception.", ex);
            }
        }

        // Define two derived exceptions to demonstrate nested exceptions.
        private class SecondLevelException : Exception
        {
            public SecondLevelException(string message, Exception inner)
                : base(message, inner)
            { }
        }

        private class ThirdLevelException : Exception
        {
            public ThirdLevelException(string message, Exception inner)
                : base(message, inner)
            { }
        }
    }
}
