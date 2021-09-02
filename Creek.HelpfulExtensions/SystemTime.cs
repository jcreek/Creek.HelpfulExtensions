using System;
using System.Collections.Generic;
using System.Text;

namespace Creek.HelpfulExtensions
{
    public static class SystemTime
    {
        /// <summary>
        /// This method exposes DateTime.Now as an instance of a function, that can be replaced in tests.
        /// </summary>
#pragma warning disable S1104 // Fields should not have public accessibility
#pragma warning disable S2223 // Non-constant static fields should not be visible
        public static Func<DateTime> Now = () => DateTime.Now;
#pragma warning restore S2223 // Non-constant static fields should not be visible
#pragma warning restore S1104 // Fields should not have public accessibility
    }
}
