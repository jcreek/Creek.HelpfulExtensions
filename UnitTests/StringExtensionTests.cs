using NUnit.Framework;
using Creek.HelpfulExtensions;

namespace UnitTests
{
    public class StringExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsSubstringBetweenFirst()
        {
            string s = "bigfishmandogcatdoghat";
            s = s.SubstringBetween("fish", "dog");
            Assert.AreEqual("fishman", s);
        }

        [Test]
        public void IsSubstringBetweenLast()
        {
            string s = "bigfishmandogcatdoghat";
            s = s.SubstringBetween("fish", "dog", true);
            Assert.AreEqual("fishmandogcat", s);
        }
    }
}
