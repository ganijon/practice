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
    public class LongestPalindrome_Naive
    {
        public string LongestPalindrome(string s)
        {
            if (s == null) return null;
            if (s == "") return "";
            if (s.Length == 1) return s;

            var medians = new List<(int key, string value)>();
            int min = 0, max = s.Length - 1;
            int prev, next;
            string left, right;

            // scan for medians
            for (int i = 0; i < s.Length; i++)
            {
                // scan for even-length 
                // palindrome median
                next = i + 1;
                if (next <= max)
                {
                    if (s[i] == s[next])
                    {
                        medians.Add((i, s.Substring(i, 2)));
                    }
                }

                // scan for odd-length 
                // palindrome median
                prev = i - 1;
                if (prev >= min && next <= max)
                {
                    if (s[prev] == s[next])
                    {
                        medians.Add((i, s[i].ToString()));
                    }
                }
            }

            var list = new List<string>();
            foreach (var median in medians)
            {
                left = s.Substring(0, median.key);
                right = (median.value.Length == 1)
                 ? right = s.Substring(median.key + 1)
                 : right = s.Substring(median.key + 2);

                if (left.Length < right.Length)
                    right = right.Substring(0, left.Length);
                else if (left.Length > right.Length)
                    left = left.Substring(left.Length - right.Length, right.Length);

                list.Add(Palindrome(left, right, median.value));
            }

            return list
                .OrderByDescending(x => x.Length)
                .DefaultIfEmpty(s[0].ToString())
                .FirstOrDefault();
        }

        private string Palindrome(string left, string right, string median)
        {
            if (left.Length == 0 || right.Length == 0)
                return median;

            if (left == new string(right.Reverse().ToArray()))
            {
                return left + median + right;
            }
            else
            {
                return Palindrome(new string(left.Skip(1).ToArray()), new string(right.SkipLast(1).ToArray()), median);
            }
        }

        [TestMethod]
        public void LongestPalindrome_Test()
        {

            Assert.AreEqual("abcxcba", LongestPalindrome("abcxcba"));
            Assert.AreEqual("abcxcba", LongestPalindrome("abcxcbaw"));
            Assert.AreEqual("abcxcba", LongestPalindrome("wabcxcba"));
            Assert.AreEqual("wabcxcbaw", LongestPalindrome("wabcxcbaw"));

            Assert.AreEqual("abcxxcba", LongestPalindrome("abcxxcba"));
            Assert.AreEqual("abcxxcba", LongestPalindrome("abcxxcbaw"));
            Assert.AreEqual("abcxxcba", LongestPalindrome("wabcxxcba"));


            Assert.AreEqual("bab", LongestPalindrome("babad"));
            Assert.AreEqual("babab", LongestPalindrome("babab"));
            Assert.AreEqual("bb", LongestPalindrome("cbbd"));
            Assert.AreEqual(null, LongestPalindrome(null));
            Assert.AreEqual("c", LongestPalindrome("cbd"));
            Assert.AreEqual("", LongestPalindrome(""));
            Assert.AreEqual("a", LongestPalindrome("a"));
            Assert.AreEqual("aa", LongestPalindrome("aa"));
            Assert.AreEqual("aaa", LongestPalindrome("aaa"));

            Assert.AreEqual("aaaa", LongestPalindrome("aaaa"));
        }
    }
}
