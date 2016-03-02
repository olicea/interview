using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class Solution
    {
        public bool IsPowerOfThree(int n)
        {
            if (n == 0) return false; //undefined
            if (n == 1) return true; //  x ^ 0
            //divide and allow some error
            return ((int)(n / 3.0)) * 3 == n;
        }

        [TestMethod]
        public void IsPowerOfThreeTest()
        {

            Assert.IsFalse(IsPowerOfThree(0));
            Assert.IsTrue(IsPowerOfThree(1));
            Assert.IsFalse(IsPowerOfThree(26));

            Assert.IsTrue(IsPowerOfThree(27));
            Assert.IsTrue(IsPowerOfThree(128 * 3));

            Assert.IsFalse(IsPowerOfThree(128 * 3 + 1));
        }
    }
}
