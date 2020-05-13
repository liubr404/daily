using NUnit.Framework;
using System.IO;
using System;

namespace MED_test
{
    public class Tests
    {
        private int[] Expected = new int[] { 5, 1, 4, 4 };
        private string[] str1 = new string[] { "intention", "abc", "hello", "lion" };
        private string[] str2 = new string[] { "execution", "dbc", "hi", "emotion" };
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestMethod1()
        {
            for (int i = 0; i < str1.Length; i++)
            {
                int result = MinimumEditDistance.program.MED(str1[i], str2[i]);
                Assert.AreEqual(Expected[i], result);
            }
        }
    }
}