using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SolutionSingleNumber3
{
    public int SingleNumber(int[] nums)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (counts.ContainsKey(nums[i]))
            {
                counts[nums[i]] = counts[nums[i]] + 1;
            }
            else
            {
                counts.Add(nums[i], 1);
            }
        }

        return counts.First(p => p.Value == 1).Key;
    }

    [TestMethod]
    public void SingleNumer3_Test()
    {
        Assert.AreEqual(4, SingleNumber(
            new int[3 * 3 + 1] { 1, 2, 3, 4, 1, 2, 3, 1, 2, 3 }));

    }
}