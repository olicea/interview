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
    public class HashyableImpTests
    {
        [TestMethod]
        public void BasicHashTest()
        {
            HashtableImp t = new HashtableImp();
            t.Add("a", "b");
            t.Add("foo", "bar");
            t.Add("b", "c");

            Assert.AreEqual("b", t.Get("a"));
            Assert.AreEqual("bar", t.Get("foo"));
            Assert.AreEqual("c", t.Get("b"));
        }

        class HashtableImp
        {
            public HashtableImp()
            {
                m_values = new LinkedList[m_size];
                m_keys = new string[m_size];
            }

            public void Add(string key, string value)
            {
                int index = Math.Abs(key.GetHashCode()) % m_size;
                if (m_values[index] == null)
                {
                    m_values[index] = new LinkedList();
                }

                m_values[index].Add(key, value);
            }

            public string Get(string key)
            {
                int index = Math.Abs(key.GetHashCode()) % m_size;
                LinkedListNode n = m_values[index]?.Find(key);
                return n?.Value;
            }

            public void Delete(string key)
            {
            }

            private int m_size = 100;
            private LinkedList[] m_values;
            private string[] m_keys;
        }
    }
}
