using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalindromeLibrary
{
    public class PalindromeCheck
    {
        public static Boolean isPalindrome(string a)
        {
            a = Regex.Replace(a, @"[^A-Za-z0-9]+", "");
            string p = a.ToLower();

            int length = p.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (p[i] != p[length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
