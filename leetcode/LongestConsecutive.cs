using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    class Program
    {
        public class Solution
        {
            public static int LongestConsecutive(int[] nums)
            {
                int temp_len = 0;
                int temp_num = 0;
                int Max_len = 0;
                foreach (int num in nums)
                {
                    if (!nums.Contains(num - 1))
                    {
                        temp_len += 1;
                        temp_num = num;
                        while (nums.Contains(temp_num + 1))
                        {
                            temp_num += 1;
                            temp_len += 1;
                        }
                        Max_len = Math.Max(temp_len, Max_len);
                        temp_len = 0;
                        temp_num = 0;
                    }
                }
                return Max_len;
            }


            public static void Main(string[] args)
            {
                int[] nums = { 100, 4, 200, 1, 3, 2 };
                Console.WriteLine(LongestConsecutive(nums));
            }
        }
    }
}
