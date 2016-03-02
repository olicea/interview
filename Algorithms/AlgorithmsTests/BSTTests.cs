using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class BSTTests
    {
        [TestInitialize]
        public void TestInit()
        {
            /*
           5
          / \
         3   9
         \   / \
          4 6   11

          */
            tree = new BSTree();
            tree.InsertValue(5);
            tree.InsertValue(9);
            tree.InsertValue(6);
            tree.InsertValue(3);
            tree.InsertValue(4);
            tree.InsertValue(11);
        }

        [TestMethod]
        public void BST_BreadthFirstSearch()
        {
            int nodesVisited = 0;
            Assert.IsNotNull(tree.BreadthFirstSearch(9, out nodesVisited));
            Assert.AreEqual(3, nodesVisited);
            Assert.IsNotNull(tree.BreadthFirstSearch(5, out nodesVisited));
            Assert.AreEqual(1, nodesVisited);
            Assert.IsNull(tree.BreadthFirstSearch(100, out nodesVisited));
            Assert.AreEqual(6, nodesVisited);
        }

        [TestMethod]
        public void Add()
        {
            Assert.IsNotNull(tree.Head);
            Assert.AreEqual(tree.Head.Value, 5);
            //left
            Assert.AreEqual(tree.Head.Left.Value, 3);
            Assert.AreEqual(tree.Head.Left.Right.Value, 4);
            //right
            Assert.AreEqual(tree.Head.Right.Value, 9);
            Assert.AreEqual(tree.Head.Right.Right.Value, 11);
            Assert.AreEqual(tree.Head.Right.Left.Value, 6);


            //traverse
            Assert.AreEqual("5 3 4 9 6 11 ", tree.ToStringTraverseLeft());
            Assert.IsTrue(tree.IsBST());

            /* 
            Not a BST tree once we add the last node
                10
              /   \  
             6     11
                    \
                     9
            */
            tree = new BSTree();
            tree.Head =
                new Node()
                {
                    Value = 10,
                    Left = new Node() { Value = 6 },
                    Right = new Node() { Value = 11 }
                };

            Assert.IsTrue(tree.IsBST());

            tree.Head.Right.Right = new Node() { Value = 9 };
            Assert.IsFalse(tree.IsBST());

        }

        [TestMethod]
        public void PrintAllPaths()
        {
            //print all paths
            List<String> paths = tree.PathsToLeafs();
            Assert.AreEqual(3, paths.Count);
            Assert.IsTrue(paths.Contains("5 3 4"));
            Assert.IsTrue(paths.Contains("5 9 6"));
            Assert.IsTrue(paths.Contains("5 9 11"));
        }

        BSTree tree;

        class BSTree
        {
            public Node Head;

            public string ToStringTraverseLeft()
            {
                string tostring = string.Empty;
                ToStringLeft(Head, ref tostring);
                return tostring;
            }

            private void ToStringLeft(Node n, ref string tostring)
            {
                if (n == null)
                {
                    return;
                }
                tostring += n.Value + " ";
                ToStringLeft(n.Left, ref tostring);
                ToStringLeft(n.Right, ref tostring);
            }

            public void InsertValue(int value)
            {
                // the tree is new initialize
                if (Head == null)
                {
                    Head = new Node() { Value = value };
                }
                InsertNode(ref Head, value);
            }

            private void InsertNode(ref Node n, int value)
            {
                if (n == null)
                {
                    n = new Node() { Value = value };
                }
                else if (n.Value > value)
                {
                    InsertNode(ref n.Left, value);
                }
                else if (n.Value < value)
                {
                    InsertNode(ref n.Right, value);
                }
            }

            List<string> m_paths;
            public List<string> PathsToLeafs()
            {
                // not thread safe
                m_paths = new List<string>();

                Path(Head, string.Empty);
                return m_paths;
            }

            public void Path(Node n, string p)
            {
                if (n == null)
                {
                    return;
                }

                // add a separator if it's not the first node in the path
                p += (string.IsNullOrEmpty(p) ? string.Empty : " ") +
                           n.Value.ToString();
                if (n.Left == null && n.Right == null)
                {
                    //leaf, add the path
                    m_paths.Add(p);
                    return;
                }
                Path(n.Left, p);
                Path(n.Right, p);
            }

            public Node BreadthFirstSearch(int v, out int visited)
            {
                Queue<Node> queue = new Queue<Node>();
                visited = 0;
                //start with the tree's head
                queue.Enqueue(Head);
                while (queue.Count > 0)
                {
                    Node n = queue.Dequeue();
                    visited++;
                    if (n.Value == v)
                    {
                        return n;
                    }
                    // get both chldren to the head
                    if (n.Left != null)
                        queue.Enqueue(n.Left);
                    if (n.Right != null)
                        queue.Enqueue(n.Right);
                }

                //not found
                return null;
            }

            //public void DeleteNode(ref Node n, int value)
            //{
            //    if (n == null)
            //    {
            //        // not found, nothing to do.
            //        return;
            //    }
            //    if (n.Value < value)
            //    {
            //        DeleteNode(ref n.Left, value);
            //    }
            //    if (n.Value > value)
            //    {
            //        DeleteNode(ref n.Right, value);
            //    }
            //    if (n.Value == value)
            //    {
            //        //found it delete it.
            //        if (n.Left == null && n.Right == null)
            //        {
            //            n = null;
            //        }
            //        else if (n.Left == null)
            //        {
            //            n = n.Right;
            //        }
            //        else if (n.Right == null)
            //        {
            //            n = n.Left;
            //        }
            //        else
            //        {
            //            n = 
            //        }
            //    }

            //}

            public bool IsBST()
            {
                return IsNodeBST(Head, int.MinValue, int.MaxValue);
            }
            private bool IsNodeBST(Node n, int min, int max)
            {
                if (n == null)
                {
                    return true;
                }

                if (n.Value < min || n.Value > max)
                {
                    // this node is not a valid tree
                    return false;
                }
                return IsNodeBST(n.Left, min, n.Value) &&
                       IsNodeBST(n.Right, n.Value, max);
            }

        }

        class Node
        {
            public int Value;
            public Node Left;
            public Node Right;
        }
    }
}
