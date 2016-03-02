using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    public class LinkedList
    {
        LinkedListNode Head;

        public void Add(string key, string value)
        {
            //Head always points to the new object 
            //An ordered list is more efficient
            LinkedListNode n = new LinkedListNode()
            {
                Key = key,
                Value = value
            };
            n.Next = Head;
            Head = n;
        }

        public LinkedListNode Find(string key)
        {
            LinkedListNode n = Head;
            while (n != null)
            {
                if (String.Equals(key, n.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return n;
                }
                n = n.Next;
            }
            return n;
        }
    }

    public class LinkedListNode
    {
        public string Key;
        public string Value;
        public LinkedListNode Next;
    }
}
