using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    class Program
    {
        public class Solution
        {
            public static IList<string> TopKFrequent(string[] words, int k)
            {
                Dictionary<string, int> count = new Dictionary<string, int>();
                IList<string> result = new List<string>();
                int temp = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    if (count.ContainsKey(words[i]))
                    {
                        count[words[i]] += 1;
                    }
                    else
                    {
                        count.Add(words[i], 1);
                    }
                }
                var orderedDict = count.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
                foreach (KeyValuePair<string, int> pair in orderedDict)
                {
                    if (temp < k)
                    {
                        result.Add(pair.Key);
                    }
                    else
                    {
                        break;
                    }
                    temp++;
                }
                return result;
            }


            public static void Main(string[] args)
            {
                string[] words = { "i", "love", "leetcode", "i", "love", "coding" };
                IList<string> result = new List<string>();
                result = TopKFrequent(words, 2);
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }
        }
    }
}
