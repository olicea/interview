using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    [TestClass]
    public class StringPermutations
    {
        [TestMethod]
        public void PermutationsTest()
        {
            List<string> permutations = Permutate("abc");
            Assert.IsTrue(permutations.Contains("abc"));
            Assert.IsTrue(permutations.Contains("acb"));
            Assert.IsTrue(permutations.Contains("bac"));
            Assert.IsTrue(permutations.Contains("bca"));
            Assert.IsTrue(permutations.Contains("cab"));
            Assert.IsTrue(permutations.Contains("cba"));
        }

        private List<string> Permutate(string str)
        {
            List<String> permutations = new List<string>();
            char[] s = str.ToCharArray();
            Permutate(s, 0, permutations);
            return permutations;
        }

        private void Permutate(char[] s, int n, List<string> permutations)
        {
            if (n == s.Length)
            {
                //add  new permutation
                permutations.Add(new string(s));
            }
            else
            {
                //get more permutations
                for (int i = n; i < s.Length; i++)
                {
                    Swap(s, i, n);
                    Permutate(s, n + 1, permutations);
                    Swap(s, i, n);
                }
            }
        }

        private void Swap(char[] s, int i, int n)
        {
            //swap element
            char tmp = s[n];
            s[n] = s[i];
            s[i] = tmp;
        }
    }
}
