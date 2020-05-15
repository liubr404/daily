using System;
using System.Diagnostics;

namespace RunExe
{
    class Program
    {
        static void Main()
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "c://users/admin/source/repos/DirectoryStatistics/DirectoryStatistics/bin/Debug/netcoreapp3.1/DirectoryStatistics.exe",
                    Arguments = "-d /Users/admin/Desktop/dailyreport -p *.txt",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                // do something with line
                Console.WriteLine(line);
            }
        }
    }
}
