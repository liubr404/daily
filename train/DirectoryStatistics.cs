﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DirectoryStatistics
{
    class day5
    {
        public static long length;
        public static double size;
        //save the length and size of the directory
        public static void Main(string[] args)
        {
            /*
            #if DEBUG
                        args = new[] { "-d /Users/admin/Desktop/dailyreport -p *.txt" };
            #endif
            */
            string filePath;
            string pattern;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (args.Length == 4 && args[0] == "-d" && args[2] == "-p")
            {
                filePath = args[1];
                pattern = args[3];
                int fileCount;
                /*for (int i = 0; i < args.Length; i++) {
                    Console.WriteLine(args[i]);
                }*/
                //debug
                string[] files = Directory.GetFiles(filePath, pattern, SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    Console.WriteLine("No file is suitable for your search");
                }
                else
                {
                    List<string> fileNames = new List<string>();
                    fileCount = files.Length;
                    //find all pattern files in the folder
                    Console.WriteLine("File name pattern: {0}", pattern);
                    foreach (string file in files)
                    {
                        FileInfo info = new FileInfo(file);
                        length += info.Length;
                        //calculate the size of current file
                        /*
                        pattern = "+" + pattern.Remove(0, 1);
                        MatchCollection match = Regex.Matches(file, @"[\w+$]" + pattern);
                        // match all .txt files.
                        foreach (Match matchFiles in match)
                        {
                            fileNames.Add(matchFiles.Groups[0].Value);
                            //Console.WriteLine(matchFiles.Groups[0].Value);
                            //debug
                        }
                        */
                        //this method using regex to get all txt name from the path
                        fileNames.Add(file.Replace(filePath, ".."));
                        //save the file names in proper format
                    }
                    size = (length / 1024f) / 1024f;
                    watch.Stop();
                    Console.WriteLine("File count:{0}\nTotal size:{1} MB({2} bytes)\nTime elapsed: {3} ms\nFile list:", fileCount, size, length, watch.ElapsedMilliseconds);
                    for (int i = 0; i < fileNames.Count; i++)
                    {
                        Console.WriteLine("--{0}", fileNames[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("pls input in correct format");
            }
            //Console.WriteLine(filePath, pattern);
        }
    }
}
