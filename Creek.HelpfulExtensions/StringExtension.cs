using System;

namespace Creek.HelpfulExtensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Returns a substring from the first occurrence of the start string to the end string.
        /// </summary>
        /// <param name="str">The string to find a substring from.</param>
        /// <param name="startString">The string to begin the substring with.</param>
        /// <param name="endString">The string that should occur immediately after the substring.</param>
        /// <param name="isLastEndStringOccurence">Allows selecting whether to use the first occurrence of the endString (default behaviour) or the last.</param>
        /// <returns>Returns the substring.</returns>
        public static string SubstringBetween(this string str, string startString, string endString, bool isLastEndStringOccurrence = false)
        {
            // Find the start index of the startString
            int startIndex = str.IndexOf(startString);

            // Find the end index of the endString
            int endIndex = isLastEndStringOccurrence ? str.LastIndexOf(endString) : str.IndexOf(endString);

            // Find the length of the string we want
            int length = endIndex - startIndex;

            // Substring(int startIndex, int length)
            return str.Substring(startIndex, length);
        }
    }
}
