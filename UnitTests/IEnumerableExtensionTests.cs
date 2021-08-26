using NUnit.Framework;
using Creek.HelpfulExtensions;
using System.Collections.Generic;

namespace UnitTests
{
    public class IEnumerableExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsSubstringBetweenFirst()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5,6,7,8,9
            };

            string indexString = string.Empty;
            string valueString = string.Empty;

            foreach (var (item, index) in list.WithIndex())
            {
                indexString += index;
                valueString += item;
            }

            Assert.AreEqual("012345678", indexString);
            Assert.AreEqual("123456789", valueString);
        }
    }
}
