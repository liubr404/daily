using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.CompilerServices;

class Day3
{
    static void Main()
    {
        Console.WriteLine(CountInTextFile("/Users/admin/Desktop/daily report/first_day.txt", true, true, true).LineCount);
        FilterLinesWithNoNumbers("/Users/admin/Desktop/daily report/first_day.txt", "/Users/admin/Desktop/daily report/first_day_temp.txt");
    }

    public struct FileCount
    {
        public string filePath;
        public int LineCount;
        public long CharCount;
        public int WrodCount;
    }

    public static FileCount CountInTextFile(string filePath, bool countLines, bool countWords, bool countChars)
    {
        if (!System.IO.File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
        //whether the file exist
        int lines = 0, words = 0;
        long chars = 0;
        using (StreamReader r = new StreamReader(filePath))
        {
            string sentence;
            // save each line
            while ((sentence = r.ReadLine()) != null)
            {
                //Console.WriteLine(sentence);
                lines++;
                string[] word = sentence.Split(' ');
                words += word.Length;
                chars += sentence.Length;
            }
        }
        FileCount result = new FileCount();
        result.filePath = filePath;
        // read one line each iteration so that use less memory.
        if (countLines)
        {
            result.LineCount = lines;
            Console.WriteLine("The number of lines in this file is " + lines);
        }
        if (countWords)
        {
            result.WrodCount = words;
            Console.WriteLine("The number of words in this file is " + words);
        }
        if (countChars)
        {
            result.CharCount = chars;
            Console.WriteLine("The number of chars in this file is " + chars);
        }
        return result;
    }

    public static void FilterLinesWithNoNumbers(string filePath, string destinationFilePath)
    {
        if (!System.IO.File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
        using (StreamReader reader = new StreamReader(filePath))
        {
            using (StreamWriter writer = new StreamWriter(destinationFilePath))
            {
                string sentence;
                Regex regex = new Regex(@".*\d+.*", RegexOptions.RightToLeft);
                while ((sentence = reader.ReadLine()) != null)
                {
                    if (regex.Match(sentence).Success)
                        continue;
                    // if the line contains number,go to next iteration.
                    writer.WriteLine(sentence);
                }
            }
        }
    }
}