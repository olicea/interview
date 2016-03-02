using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class ReversePrintCharList
    {
        //Create a linked list with 3 char (A,B,C) in it and print the list in reverse.
        [TestMethod]
        public void ReversePrint_Test()
        {
            LinkedListImp list = new LinkedListImp();

            //empty list
            Assert.AreEqual(string.Empty, list.ReversePrint());
            //one item
            list.AddToEnd('A');
            Assert.AreEqual("A", list.ReversePrint());
            //full list
            list.AddToEnd('B');
            list.AddToEnd('C');
            Assert.AreEqual("CBA", list.ReversePrint());
        }

        class LinkedListImp
        {
            LinkedListNodeImp Head;
            LinkedListNodeImp Last;

            public string ReversePrint()
            {
                return ReversePrint(Head);
            }

            private string ReversePrint(LinkedListNodeImp n)
            {
                if (n == null)
                {
                    return string.Empty;
                }
                return ReversePrint(n.Next) + n.Value;
            }

            public void AddToEnd(char c)
            {
                LinkedListNodeImp n = new LinkedListNodeImp() { Value = c };
                if (Last != null)
                {
                    // not empty, ad to the bottom
                    Last.Next = n;
                }
                if (Head == null)
                {
                    //it was empty, point to it as the first
                    Head = n;
                }
                Last = n;
            }
        }

        class LinkedListNodeImp
        {
            public LinkedListNodeImp Next;
            public Char Value;
        }
    }
}
