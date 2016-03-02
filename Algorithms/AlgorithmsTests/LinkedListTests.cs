using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class LinkedListsTests
    {
        [TestMethod]
        public void FindKthTests()
        {
            // build the lsit  {1, 4, 6, 3, 6, 7}
            LinkedListImp list = new LinkedListImp();
            list.AddToEnd(1);
            list.AddToEnd(4);
            list.AddToEnd(6);
            list.AddToEnd(3);
            list.AddToEnd(6);
            list.AddToEnd(7);

            Assert.AreEqual("1 4 6 3 6 7", list.ToString());

            Assert.AreEqual(1, list.FindKthToLast(6).Value);
            Assert.AreEqual(3, list.FindKthToLast(3).Value);
            Assert.AreEqual(6, list.FindKthToLast(2).Value);
            Assert.AreEqual(7, list.FindKthToLast(1).Value);
            Assert.IsNull(list.FindKthToLast(7));
        }

        class LinkedListImp
        {
            public LinkedListImpNode Head;
            public LinkedListImpNode Last;


            /// <summary>
            /// Finds the Kth to the last element
            /// i.e. if the list is { 1, 4, 6, 3, 6, 7 }
            /// when k = 2, kth to last is 6
            /// when k = 1, kth to last is 7
            /// when k = 10000, kth is not defined, since there aren't 
            ///                 that many items on the list  
            /// </summary>
            /// <param name="k"></param>
            /// <returns></returns>
public LinkedListImpNode FindKthToLast(int k)
{
    LinkedListImpNode p = Head;
    LinkedListImpNode kNode = Head;
    //first advance k
    int i = 0;
    for (; i < k && p != null; i++)
    {
        p = p.Next;
    }
    if (p == null && i < k)
    {
        // the list is too small, we reached the end of the list
        // and we did not find k elements, fail here.
        return null;
    }

    //move the pointer to the end, sk moves with it
    while (p != null)
    {
        p = p.Next;
        kNode = kNode.Next;
    }
    return kNode;
}

            public void AddToBeggining(Object value)
            {
                LinkedListImpNode n = new LinkedListImpNode()
                {
                    Value = value
                };
                n.Next = Head;
                Head = n;

                if (Last == null)
                {
                    // it was empty, set last too
                    Last = n;
                }
            }

            public void AddToEnd(Object value)
            {
                LinkedListImpNode n = new LinkedListImpNode()
                {
                    Value = value
                };
                if (Last != null)
                {
                    Last.Next = n;
                }
                else
                {
                    // it was empty, set head too
                    Head = n;
                }

                Last = n;
            }

            public override string ToString()
            {
                StringBuilder s = new StringBuilder();
                LinkedListImpNode n = Head;
                while (n != null)
                {
                    if (s.Length > 0)
                    {
                        s.Append(" ");
                    }
                    s.Append(n.Value.ToString());
                    n = n.Next;
                }
                return s.ToString();
            }
        }
        class LinkedListImpNode
        {
            public Object Value;
            public LinkedListImpNode Next;
        }
    }
}
