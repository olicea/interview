using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class ListUnionAndIntersection
    {
        private NodeList Intersection(NodeList l1, NodeList l2)
        {
            NodeList list = new NodeList();
            Node n = l1.Head;
            while (n != null)
            {
                if (l2.Contains(n.Value))
                {
                    list.Add(n.Value);
                }
                n = n.Next;
            }
            return list;
        }

        private NodeList Union(NodeList l1, NodeList l2)
        {
            NodeList list = new NodeList();
            Node n = l1.Head;
            Node m = l2.Head;

            //Add both lists, the duplicated items will be ignored
            while (n != null || m != null)
            {
                if (n != null)
                {
                    list.Add(n.Value);
                    n = n.Next;
                }
                if (m != null)
                {
                    list.Add(m.Value);
                    m = m.Next;
                }
            }
            return list;
        }

        bool AreListsEqual(NodeList l1, NodeList l2)
        {
            Node p1 = l1.Head;
            Node p2 = l2.Head;

            while (p1 != null && p2 != null)
            {
                //same value: all values shold be equal
                if (p1.Value != p2.Value)
                {
                    return false;
                }
                p1 = p1.Next;
                p2 = p2.Next;
            }
            //same length: both lists shoudl be at the end
            return p1 == null && p2 == null;
        }

        class NodeList
        {
            public Node Head;
            public static NodeList FromArray(int[] values)
            {
                NodeList list = new NodeList();

                for (int i = 0; i < (values?.Length ?? 0); i++)
                    list.Add(values[i]);
                return list;
            }

            public void Add(int v)
            {
                Node prev = null;
                Node n = Head;
                //Find the spot to place it and the previous item
                while (n != null && n.Value < v)
                {
                    prev = n;
                    n = n.Next;
                }
                //avoid duplication, don't add the item if it exists
                if (n != null && n.Value == v)
                {
                    return;
                }
                Node newNode = new Node()
                {
                    Value = v,
                    Next = n
                };
                if (prev != null)
                {
                    prev.Next = newNode;
                }
                else
                {
                    Head = newNode;
                }
            }

            public bool Contains(int v)
            {
                Node n = Head;
                while (n != null)
                {
                    if (n.Value == v)
                    {
                        return true;
                    }
                    n = n.Next;
                }
                // not found
                return false;
            }

            public override string ToString()
            {
                Node p = Head;
                String s = string.Empty;
                while (p != null)
                {
                    s += p.Value.ToString() + " ";
                    p = p.Next;
                }
                return s;
            }

        }

        class Node
        {
            public int Value;
            public Node Next;
        }

        [TestMethod]
        public void Test_List()
        {
            Assert.IsTrue(
                AreListsEqual(
                    NodeList.FromArray(new[] { 1 }),
                    Union(NodeList.FromArray(new[] { 1 }),
                          NodeList.FromArray(null))));

            Assert.IsTrue(
                AreListsEqual(
                    NodeList.FromArray(new[] { 0, 1 }),
                    Union(NodeList.FromArray(new[] { 1 }),
                          NodeList.FromArray(new[] { 0 }))));
            Assert.IsTrue(
                AreListsEqual(
                    NodeList.FromArray(new[] { 1, 3, 5, 7, 9, 14, 456, 670, 1234 }),
                    Union(NodeList.FromArray(new[] { 1, 3, 456, 670, 1234 }),
                          NodeList.FromArray(new[] { 3, 5, 7, 9, 14, 670 }))));

            Assert.IsTrue(
              AreListsEqual(
                  NodeList.FromArray(new[] { 3, 670 }),
                  Intersection(NodeList.FromArray(new[] { 1, 3, 456, 670, 1234 }),
                               NodeList.FromArray(new[] { 3, 5, 7, 9, 14, 670 }))));
            Assert.IsTrue(
              AreListsEqual(
                  NodeList.FromArray(null),
                  Intersection(NodeList.FromArray(new[] { 1, 3}),
                               NodeList.FromArray(null))));
        }
    }
}
