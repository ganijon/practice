using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Strings
{
    ///
    /// https://leetcode.com/problems/roman-to-integer/
    ///
    [TestClass]
    public class RomanNumbers
    {
        public int RomanToInt(string s)
        {
            int[] n = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'I':
                        {
                            n[i] = 1;

                            if (i + 1 < s.Length)
                            {
                                if (s[i + 1] == 'V' || s[i + 1] == 'X')
                                {
                                    n[i] = -1;
                                }
                            }
                        }
                        break;

                    case 'V': n[i] = 5; break;

                    case 'X':
                        {
                            n[i] = 10;

                            if (i + 1 < s.Length)
                            {
                                if (s[i + 1] == 'L' || s[i + 1] == 'C')
                                {
                                    n[i] = -10;
                                }
                            }
                        }
                        break;
                    case 'L': n[i] = 50; break;
                    case 'C':
                        {
                            n[i] = 100;

                            if (i + 1 < s.Length)
                            {
                                if (s[i + 1] == 'D' || s[i + 1] == 'M')
                                {
                                    n[i] = -100;
                                }
                            }
                        }
                        break;
                    case 'D': n[i] = 500; break;
                    case 'M': n[i] = 1000; break;
                }
            }

            int result = 0;
            for (int i = 0; i < n.Length; i++)
            {
                result += n[i];
            }
            return result;
        }

        [TestMethod]
        public void Test_RomanToInt()
        {
            Assert.AreEqual(1, RomanToInt("I"));
            Assert.AreEqual(2, RomanToInt("II"));
            Assert.AreEqual(3, RomanToInt("III"));
            Assert.AreEqual(4, RomanToInt("IV"));
            Assert.AreEqual(9, RomanToInt("IX"));
            Assert.AreEqual(40, RomanToInt("XL"));
            Assert.AreEqual(90, RomanToInt("XC"));
            Assert.AreEqual(400, RomanToInt("CD"));
            Assert.AreEqual(900, RomanToInt("CM"));

            Assert.AreEqual(58, RomanToInt("LVIII"));
            Assert.AreEqual(1994, RomanToInt("MCMXCIV"));
            Assert.AreEqual(997, RomanToInt("CMXCVII"));
        }
    }
}

