using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//[TestClass]
public class SolutionConvertToTitle
{
    public string ConvertToTitle(int n)
    {
        //add the first item;
        string s = string.Empty;
        int size = (int)'Z' - (int)'A' + 1;
        int digit = n;
        while (digit > 0)
        {
            char c = ToChar(digit);
            s = c + s;
            //lose a digit
            digit -= size;
            //carrying 1 (or A) 
            //if (digit == 0)
            //{
            //    s = 'A' + s;
            //}
        }
        return s;
    }

    private char ToChar(int n)
    {
        int a = (int)'A';
        n = (n - 1) % 26;
        return (char)(a + n);
    }


    public void ConvertToTitle_Test()
    {
        Assert.AreEqual("A", ConvertToTitle(1));
        Assert.AreEqual("B", ConvertToTitle(2));
        Assert.AreEqual("Z", ConvertToTitle(26));

        Assert.AreEqual("AA", ConvertToTitle(27));
        Assert.AreEqual("AB", ConvertToTitle(28));
        Assert.AreEqual("AAA", ConvertToTitle(53));
        Assert.AreEqual("AAB", ConvertToTitle(54));


    }

}