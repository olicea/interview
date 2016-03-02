using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class ReverseATree
    {
        [TestMethod]
        public void Reverse_Test()
        {
            /*       1
                    / \
                   2   4
                  /     \
                 3       5
            */
            Node head = new Node()
            {
                Value = 1,
                Left = new Node()
                {
                    Value = 2,
                    Left = new Node()
                    {
                        Value = 3
                    }
                },
                Right = new Node()
                {
                    Value = 4,
                    Right = new Node()
                    {
                        Value = 5
                    }
                }
            };

            Reverse(head);

            Assert.AreEqual(1, head.Value);
            Assert.AreEqual(4, head.Left.Value);
            Assert.AreEqual(2, head.Right.Value);
            Assert.AreEqual(5, head.Left.Left.Value);
            Assert.AreEqual(3, head.Right.Right.Value);
        }

        private void Reverse(Node n)
        {
            if (n == null)
            {
                return;
            }

            Node tmp = n.Left;
            n.Left = n.Right;
            n.Right = tmp;

            Reverse(n.Left);
            Reverse(n.Right);
        }
        class Node
        {
            public Object Value;
            public Node Left;
            public Node Right;
        }
    }
}
