using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class AreParenthesisBalanced
    {
        private bool AreBalanced(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                //and empty string is always balanced
                return true;
            }

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    //if it is a openning, then queue it and check later 
                    case '(':
                        stack.Push(')');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    //now check the closing 
                    case ')':
                        if (')' != stack.Pop())
                            return false;
                        break;
                    case ']':
                        if (']' != stack.Pop())
                            return false;
                        break;
                    case '}':
                        if ('}' != stack.Pop())
                            return false;
                        break;
                    default:
                        throw new ApplicationException("Unexpected character.");
                }
            }
            // it the stack is empty, then the string is balanced
            return stack.Count == 0;
        }

        [TestMethod]
        public void BalancedTests()
        {
            Assert.IsTrue(AreBalanced(null));
            Assert.IsTrue(AreBalanced(string.Empty));
            Assert.IsTrue(AreBalanced("()"));
            Assert.IsTrue(AreBalanced("(((((()))))){{{{{()}}}}}"));
            Assert.IsTrue(AreBalanced("()[]"));
            Assert.IsTrue(AreBalanced("()[{}]"));
            Assert.IsFalse(AreBalanced("("));
            Assert.IsFalse(AreBalanced("({)}"));
            Assert.IsFalse(AreBalanced("((((({{{{{"));
        }
    }
}