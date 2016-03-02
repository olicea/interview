using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    class Node
    {
        private Node left;
        private Node right;
        private int val;

        public int Value
        {
            get { return val; }
        }

        public Node Left
        {
            get { return left; }
        }

        public Node Right
        {
            get { return right; }
        }

        public Node(int val, Node left, Node right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class BinaryTree
    {
        private Node head;

        public Node Head {
            get { return head; }
        }

        public Node Find(int val)
        {
            Node node = Head;
            while (node!= null)
            {
                if (node.Value == val)
                {
                    return node;
                }
                else if (node.Value < val)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return node;
        }

        public Node FindRecursive(Node node, int value)
        {
            if (node == null || node.Value == value)
            {
                //end of the line, or found 
                return node;
            }

            if (node.Value < value)
            {
                return FindRecursive(node.Left, value);
            }
            else
            {
                return FindRecursive(node.Right, value);
            }
        }

        public void Add(Node node, int val)
        {
            if (node != null)
            { 
                if (node.Value < )
                new Node(val, null, null);
            }
        }

    }
}
