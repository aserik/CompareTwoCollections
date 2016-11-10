using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class CollectionComparerTests
    {
        [TestMethod()]
        public void CompareEmptyAndNotEmpty_ShouldBeNotEqualTest()
        {
            var col1 = new[] { 1, 2, 3, 4, 5 };
            var col2 = new int[] { };
            var result = CollectionComparer.Compare(col1, col2);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void CompareTheSameElementsOrder_ShouldBeEqualTest()
        {
            var col1 = new[] { 1, 2, 3, 4, 5 };
            var col2 = new int[] { 1, 2, 3, 4, 5 };
            var result = CollectionComparer.Compare(col1, col2);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CompareTheDifferentElementsOrder_ShouldNotBeEqualTest()
        {
            var col1 = new[] { 1, 2, 3, 4, 5 };
            var col2 = new int[] { 1, 3, 2, 4, 5 };
            var result = CollectionComparer.Compare(col1, col2);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CompareTheDifferentElements_ShouldNotBeEqualTest()
        {
            var col1 = new[] { 1, 2, 3, 4, 5 };
            var col2 = new int[] { 1, 3, 2, 4, 4 };
            var result = CollectionComparer.Compare(col1, col2);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void CompareNullWithElements_ShouldNotBeEqualTest()
        {
            var col2 = new int[] { 1, 3, 2, 4, 4 };
            var result = CollectionComparer.Compare(null, col2);
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void CompareElementsWithNull_ShouldNotBeEqualTest()
        {
            var col1 = new int[] { 1, 3, 2, 4, 4 };
            var result = CollectionComparer.Compare(col1, null);
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void CompareNullWithNull_ShouldBeEqualTest()
        {
            var result = CollectionComparer.Compare(null, null);
            Assert.IsTrue(result);
        }
    }
}