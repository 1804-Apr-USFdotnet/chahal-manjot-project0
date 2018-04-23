using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeLibrary;

namespace PalindromeTest
{
    [TestClass]
    public class PalindromeTestClass
    {
        [TestMethod]
        public void TestPalindrome()
        {
            string a = "racecar";
            Boolean expected = true;

            Boolean result = PalindromeCheck.isPalindrome(a);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPalindrome1()
        {
            string a = "Racecar";
            Boolean expected = true;

            Boolean result = PalindromeCheck.isPalindrome(a);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPalindrome2()
        {
            string a = "1221";
            Boolean expected = true;

            Boolean result = PalindromeCheck.isPalindrome(a);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPalindrome3()
        {
            string a = "never Odd, or Even.";
            Boolean expected = true;

            Boolean result = PalindromeCheck.isPalindrome(a);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPalindrome4()
        {
            string a = "1231";
            Boolean expected = false;

            Boolean result = PalindromeCheck.isPalindrome(a);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPalindrome5()
        {
            string a = "aBc";
            Boolean expected = false;

            Boolean result = PalindromeCheck.isPalindrome(a);

            Assert.AreEqual(expected, result);
        }
    }
}
