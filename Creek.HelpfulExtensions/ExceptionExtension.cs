using System;
using System.Collections.Generic;
using System.Text;

namespace Creek.HelpfulExtensions
{
    public static class ExceptionExtension
    {
        /// <summary>
        /// Returns a string of the message of the first/root/base exception in an exception stack.
        /// </summary>
        /// <param name="ex">The Exception stack to find the first/root/base exception within.</param>
        /// <returns>Returns the first/root/base exception message string.</returns>
        public static string BaseExceptionMessage(this Exception ex)
        {
            Exception baseEx = ex.GetBaseException();
            return baseEx.Message;
        }

        /// <summary>
        /// Returns a single string of the message and stack trace of the first/root/base exception in an exception stack.
        /// </summary>
        /// <param name="ex">The Exception stack to find the first/root/base exception within.</param>
        /// <returns>Returns the first/root/base exception message and stack trace as a single string, separated by " :: ".</returns>
        public static string BaseExceptionMessageAndStackTrace(this Exception ex)
        {
            Exception baseEx = ex.GetBaseException();
            return GenerateMessageAndStackTraceString(baseEx);
        }

        /// <summary>
        /// Returns a list of the exception messages of each nested exception in an exception stack.
        /// </summary>
        /// <param name="ex">The Exception stack.</param>
        /// <returns>Returns a list of the exception messages of each nested exception in an exception stack.</returns>
        public static List<string> AllInnerExceptionMessages(this Exception ex)
        {
            return GetAllInnerExceptionMessagesAndStackTraces(ex, includeStackTraces: false);
        }

        /// <summary>
        /// Returns a list of single strings of the message and stack trace of each nested exception in an exception stack.
        /// </summary>
        /// <param name="ex">The Exception stack.</param>
        /// <returns>Returns a list with a string for each nested exception in an exception stack containing the exception message and stack trace as a single string, separated by " :: ".</returns>
        public static List<string> AllInnerExceptionMessagesAndStackTraces(this Exception ex)
        {
            return GetAllInnerExceptionMessagesAndStackTraces(ex, includeStackTraces: true);
        }

        private static List<string> GetAllInnerExceptionMessagesAndStackTraces(Exception ex, bool includeStackTraces)
        {
            List<string> exceptionMessagesAndStackTraces = new List<string>();

            Exception inner = ex.InnerException;

            exceptionMessagesAndStackTraces.Add(
                includeStackTraces ? GenerateMessageAndStackTraceString(ex)
                : ex.Message);

            while (inner != null)
            {
                exceptionMessagesAndStackTraces.Add(
                includeStackTraces ? GenerateMessageAndStackTraceString(inner)
                : inner.Message);
                inner = inner.InnerException;
            }

            // We've now reached the end of the exceptions, so can return the error messages
            return exceptionMessagesAndStackTraces;
        }

        private static string GenerateMessageAndStackTraceString(Exception ex)
        {
            return $"{ex.Message} :: {ex.StackTrace}";
        }
    }
}
