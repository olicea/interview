using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class Solution_Singlenumber
    {
        public int SingleNumber(int[] nums)
        {
            HashSet<int> lonely = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (lonely.Contains(nums[i]))
                {
                    //if we haven't seen it, add it
                    lonely.Remove(nums[i]);
                }
                else
                {
                    //if it was already there, remove it
                    lonely.Add(nums[i]);
                }
            }

            //only one remains
            return lonely.First();
        }

        [TestMethod]
        public void SingleNumber_Tests()
        {
            Assert.AreEqual(2, SingleNumber( new int[] { 1, 2, 3, 1, 3 }));
            Assert.AreEqual(2, SingleNumber(new int[] { 1, 2, 1 }));
            Assert.AreEqual(2, SingleNumber(new int[] { 2 }));
        }
    }
}
