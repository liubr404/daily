using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    class Program
    {
        public class Solution
        {
            private static char top;
            public static bool IsValid(string s)
            {
                Dictionary<char, char> map = new Dictionary<char, char>();
                List<char> stack = new List<char>();
                // Make a map for testing cases
                map.Add('(', ')');
                map.Add('[', ']');
                map.Add('{', '}');
                map.Add('#', '#');
                for (int i = 0; i < s.Length; i++)
                {
                    // if current char is a closing symbol
                    if (map.ContainsValue(s[i]))
                    {
                        try
                        {
                            top = stack[stack.Count - 1];
                        }
                        //the stack may be empty
                        catch (ArgumentOutOfRangeException)
                        {
                            top = '#';
                        }
                        //if the toppest char in stack is matched with current char
                        //pop the toppest element
                        if (map[top] == s[i])
                        {
                            stack.RemoveAt(stack.Count - 1);
                        }
                        //return false
                        else
                        {
                            return false;
                        }
                    }
                    // if current char is an open symbol
                    else
                    {
                        stack.Add(s[i]);
                    }
                }
                // return whether the stack is empty
                return !stack.Any();
            }

            public static void Main(string[] args)
            {
                Console.WriteLine(IsValid("()([)]"));
            }
        }
    }
}
