using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests
{
    [TestClass]
    public class MagicIndex
    {
        [TestMethod]
        public void MagicIndex_Test()
        {
            Assert.AreEqual(0, FindMagicIndex(new int[] { 0 }));
            Assert.AreEqual(1, FindMagicIndex(new int[] { -1, 1 }));
            Assert.AreEqual(-1, FindMagicIndex(new int[] { -1, 2 }));
            Assert.AreEqual(5, FindMagicIndex(new int[] { -1, 0, 1, 2, 3, 5 }));
        }

        private int FindMagicIndex(int[] v)
        {
            for (int i = 0; i < v.Length;)
            {
                if (v[i] == i)
                    return i;
                i++;
            }
            return -1;
        }
    }
}
