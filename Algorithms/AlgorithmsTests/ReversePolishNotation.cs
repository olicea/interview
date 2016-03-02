using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class ReversePolishNotation
    {
        private int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            Queue<int> queue = new Queue<int>();
            string[] items = s.Split(new[] { ' ' });
            for (int i = 0; i < items.Length; i++)
            {
                int n;
                if (int.TryParse(items[i], out n))
                {
                    //n has the int value
                }
                else if (IsOperator(items[i]))
                {
                    int a = queue.Dequeue();
                    int b = queue.Dequeue();

                    n = Operate(items[i], a, b);
                }

                // enqueue the result or the number
                queue.Enqueue(n);
            }
            //return the last number form the queue
            return queue.Dequeue();
        }

        private int Operate(string o, int a, int b)
        {
            switch (o)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    throw new ApplicationException("Operator not suported.");
            }
        }

        private bool IsOperator(string s)
        {
            return s.Equals("+", StringComparison.OrdinalIgnoreCase) ||
                s.Equals("-", StringComparison.OrdinalIgnoreCase) ||
                s.Equals("*", StringComparison.OrdinalIgnoreCase) ||
                s.Equals("/", StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void RPN_Test()
        {
            Assert.AreEqual(0, Calculate(string.Empty));
            Assert.AreEqual(7, Calculate("3 4 +"));
            Assert.AreEqual(2, Calculate("6 3 /"));
            Assert.AreEqual(19, Calculate("3 5 * 4 +"));
            Assert.AreEqual(1, Calculate("10 2 / 4 -"));
        }
    }
}
