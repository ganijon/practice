using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Strings.Palindrome
{
    ///
    /// https://leetcode.com/problems/longest-palindromic-substring
    ///
    [TestClass]
    public class LongestPalindrome_BruteForce
    {
        HashSet<(int i, int j)> h;
        string testString;

        public string LongestPalindrome(string s)
        {
            if (s == null) return null;
            if (s.Length < 1) return "";
            if (s.Length == 1) return s;

            h = new HashSet<(int i, int j)>();
            testString = s;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    isPalindrome(i, j);
                }
            }

            var idx = h.OrderByDescending(x => x.j - x.i).FirstOrDefault();

            return s.Substring(idx.i, idx.j + 1 - idx.i);
        }

        private bool isPalindrome(int i, int j)
        {
            if (h.Contains((i, j)))
                return true;

            string s = testString.Substring(i, j - i);
            return s == s.Reverse().ToString();
        }

        [TestMethod]
        public void LongestPalindrome_Test()
        {

            //Assert.AreEqual("abcxcba", LongestPalindrome("abcxcba"));
            //Assert.AreEqual("abcxcba", LongestPalindrome("abcxcbaw"));
            //Assert.AreEqual("abcxcba", LongestPalindrome("wabcxcba"));
            //Assert.AreEqual("wabcxcbaw", LongestPalindrome("wabcxcbaw"));

            //Assert.AreEqual("abcxxcba", LongestPalindrome("abcxxcba"));
            //Assert.AreEqual("abcxxcba", LongestPalindrome("abcxxcbaw"));
            //Assert.AreEqual("abcxxcba", LongestPalindrome("wabcxxcba"));


            //Assert.AreEqual("bab", LongestPalindrome("babad"));
            //Assert.AreEqual("babab", LongestPalindrome("babab"));
            //Assert.AreEqual("bb", LongestPalindrome("cbbd"));
            //Assert.AreEqual(null, LongestPalindrome(null));
            //Assert.AreEqual("c", LongestPalindrome("cbd"));
            //Assert.AreEqual("", LongestPalindrome(""));
            //Assert.AreEqual("a", LongestPalindrome("a"));
            //Assert.AreEqual("aa", LongestPalindrome("aa"));
            //Assert.AreEqual("aaa", LongestPalindrome("aaa"));

            //Assert.AreEqual("aaaa", LongestPalindrome("aaaa"));
        }
    }
}
