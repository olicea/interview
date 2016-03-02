using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class ReverseAndPalindrome
    {
        [TestMethod]
        public void Palindrome_Tests()
        {
            Assert.IsTrue(IsPalindrome(string.Empty));
            Assert.IsTrue(IsPalindrome("a"));
            Assert.IsTrue(IsPalindrome("aa"));
            Assert.IsTrue(IsPalindrome("aba"));
            Assert.IsTrue(IsPalindrome("abcdefghgfedcba"));
            Assert.IsFalse(IsPalindrome("ab"));
            Assert.IsFalse(IsPalindrome("abbcba"));
        }

        [TestMethod]
        public void ReverseString_Tests()
        {
            Assert.AreEqual("a", ReverseString("a"));
            Assert.AreEqual("ab", ReverseString("ba"));
            Assert.AreEqual("fedcba", ReverseString("abcdef"));
        }

        private string ReverseString(string o)
        {
            //switch the first half against the second half
            char[] s = o.ToCharArray();
            for (int i = 0; i < s.Length / 2; i++)
            {
                char t = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = t;
            }
            return new string(s);
        }

        private bool IsPalindrome(string s)
        {
            //check the fisrt half against the second half
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
