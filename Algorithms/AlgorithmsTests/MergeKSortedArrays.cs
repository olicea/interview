using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class MergeKSortedArrays
    {
        [TestMethod]
        public void MergeKSortedArrays_Test()
        {
            //define the arrays
            int[][] arr = new int[][]
                {
                    new int[] { 2, 5 ,8 ,12},
                    new int[] { 4, 9 ,22, 23},
                    new int[] { 2, 105, 106,1000}
                };

            Assert.IsTrue(AreArraysEqual(
                new int[] { 2, 2, 4, 5, 8, 9, 12, 22, 23, 105, 106, 1000 },
                MergeArrays(arr)));
        }

        //add them into an ordered linked list
        private int[] MergeArrays(int[][] arr)
        {
            if (arr == null)
            {
                return null;
            }

            OrderedLinked list = new OrderedLinked();
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr[i].Length; j++)
                {
                    list.Add(arr[i][j]);
                }

            return list.ToArray();
        }

        //compare each item on the array ( for validation)
        private bool AreArraysEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        class OrderedLinked
        {
            LinkedListNodeImp Head;
            private int size = 0;
            public void Add(int value)
            {
                LinkedListNodeImp p = Head;
                LinkedListNodeImp prev = null;
                LinkedListNodeImp c = new LinkedListNodeImp() { Value = value };
                while (p != null && p.Value < value)
                {
                    prev = p;
                    p = p.Next;
                }
                if (prev != null)
                {
                    //not the first element inserti it
                    prev.Next = c;
                }
                else
                {
                    //first element, add it to the head
                    Head = c;
                }
                c.Next = p;
                //keep track of the size for later
                size++;
            }

            public int[] ToArray()
            {
                int[] arr = new int[size];

                // add each one in order to the new array
                LinkedListNodeImp p = Head;
                int i = 0;
                while (p != null)
                {
                    arr[i++] = p.Value;
                    p = p.Next;
                }
                return arr;
            }
        }

        class LinkedListNodeImp
        {
            public int Value;
            public LinkedListNodeImp Next;
        }
    }
}
