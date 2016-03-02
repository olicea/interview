using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class PrefixTreeTests
    {
        [TestMethod]
        public void PrefixTest()
        {
            //TODO: fix it
#if false
            PrefixTree tree = new PrefixTree();
            tree.InsertPrefixNode(ref tree.Head, "man");
            tree.InsertPrefixNode(ref tree.Head, "many");
            tree.InsertPrefixNode(ref tree.Head, "mucho");



            Assert.IsTrue(tree.IsPrefix("man"));
            Assert.IsTrue(tree.IsPrefix("many"));
            Assert.IsTrue(tree.IsPrefix("mucho"));
            Assert.IsFalse(tree.IsPrefix("ma"));
#endif
        }

        class PrefixTree
        {
            public PrefixNode Head = null;

            public void InsertPrefixNode(ref PrefixNode n, string s)
            {
                PrefixNode child;
                if (n == null)
                {
                    n = child = new PrefixNode(s[0]);
                }
                else if (null == (child = n.Children.Find(ch => ch.Value == s[0])))
                {
                    child = new PrefixNode(s[0]);
                    n.Children.Add(child);
                }

                //add the tail
                if (s.Length > 1)
                {
                    InsertPrefixNode(ref child, s.Substring(1));
                }
                else
                {
                    //last one, add the terminator
                    child.Children.Add(new PrefixNode('*'));
                }
            }

            public bool IsPrefix(string prefix)
            {
                if (string.IsNullOrEmpty(prefix))
                {
                    return false;
                }
                if (Head == null)
                {
                    return false;
                }

                PrefixNode n = Head;
                for (int i = 0; i < prefix.Length; i++)
                {
                    if (n == null)
                    {
                        return false;
                    }
                    if (n.Value != prefix[i])
                    {
                        return false;
                    }
                    PrefixNode child = n.Children.Find(c => c.Value == prefix[i]);
                    if (child == null)
                    {
                        return false;
                    }
                    n = child;
                }
                return n != null && n.Children.Contains(new PrefixNode('*'));
            }
        }

        class PrefixNode
        {
            public char Value;
            public List<PrefixNode> Children;

            public PrefixNode(char value, List<PrefixNode> children = null)
            {
                this.Value = value;
                Children = new List<PrefixNode>();
                if (children != null)
                {
                    children.AddRange(children);
                }
            }
        }
    }
}
