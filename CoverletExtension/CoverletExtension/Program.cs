using System;
using System.Collections.Generic;

namespace CoverletExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Coverlet Json Parser");
            Console.WriteLine();
            CoverletJsonParser coverletJsonParser = new CoverletJsonParser();

            List<CoverageResult> coverageResults = coverletJsonParser.Parse(args[0]);

            CoverageMissPrinter coverageMissPrinter = new CoverageMissPrinter();
            coverageMissPrinter.Print(coverageResults[0]);
        }
    }
}