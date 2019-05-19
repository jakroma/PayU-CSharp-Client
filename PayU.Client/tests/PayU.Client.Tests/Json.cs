using System;
using System.IO;
using Newtonsoft.Json;
using Xunit;

namespace PayU.Client.Tests
{
    public static class Json
    {
        private static readonly string testFilesDirectory = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "testFiles");

        public static string ReadFromTestFiles(string fileName)
        {
            Console.WriteLine(testFilesDirectory);
            string pathToFile = Path.Combine(testFilesDirectory, fileName);
            return File.ReadAllText(pathToFile);
        }
    }
}