using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class CompressSeriesNumber
    {
        [TestMethod]
        public void CompressSeries_Test()
        {
            // Give the count and the number following in the series. 
            // for   e.g 1122344 first line output : 21221324 
            // next line : 12112211131214 and so on... 

            Assert.AreEqual(string.Empty, CompressSeries(string.Empty));
            Assert.AreEqual(string.Empty, CompressSeries(null));
            Assert.AreEqual(CompressSeries("1"), "11");
            Assert.AreEqual(CompressSeries("1122344"), "21221324");
            Assert.AreEqual(CompressSeries("21221324"), "12112211131214");
            Assert.AreEqual(CompressSeries("12112211131214"), "11122122311311121114");
        }

        public void ProcessInput()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                //compress, then the output becomes the input
                string o = CompressSeries(s);
                Console.WriteLine(o);
                s = o;
            }
        }

        private string CompressSeries(string s)
        {
            string o = string.Empty;
            for (int i = 0; i < (s?.Length ?? 0);)
            {
                int j = i;
                do
                {
                    i++; //move to the next char
                } while (i < s.Length && s[j] == s[i]);
                o += (i - j).ToString() + s[j];
            }
            return o;
        }
    }
}
