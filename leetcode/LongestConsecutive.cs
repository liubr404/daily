using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    class Program
    {
        public class Solution
        {
            public static int LongestConsecutive(int[] nums_)
            {
                // Dictinary find is O(1) operation while list or array is O(n)
                // Remove duplicates
                nums_ = nums_.Distinct().ToArray();
                // save in Dictionary(or hashset)
                Dictionary<int, int> nums = new Dictionary<int, int>();
                foreach (int num in nums_)
                {
                    if (nums.ContainsKey(num))
                    {
                        nums[num] += 1;
                    }
                    else
                    {
                        nums.Add(num, 1);
                    }
                }
                int temp_len = 0;
                int temp_num = 0;
                int Max_len = 0;
                foreach (int num in nums.Keys)
                {
                    if (!nums.Keys.Contains(num - 1))
                    {
                        temp_len += 1;
                        temp_num = num;
                        while (nums.Keys.Contains(temp_num + 1))
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
