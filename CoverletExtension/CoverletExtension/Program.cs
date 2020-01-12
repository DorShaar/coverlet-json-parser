using System;

namespace CoverletExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Coverlet Json Parser");
            Console.WriteLine();
            CoverletJsonParser coverletJsonParser = new CoverletJsonParser();

            CoverageResult coverageResult = coverletJsonParser.Parse(args[0]);


            foreach(var module in coverageResult.Modules)
            {
                Console.WriteLine($"Module: {module.Key}");

                foreach(var document in module.Value.Documents)
                {
                    Console.WriteLine($"Document: {document.Key}");

                    foreach (var @class in document.Value.Classes)
                    {
                        Console.WriteLine($"Class: {@class.Key}");

                        foreach (var method in @class.Value.Methods)
                        {
                            Console.WriteLine($"Method: {method.Key}");

                            foreach (var line in method.Value.Lines)
                            {
                                if(line.Value == 0)
                                    Console.WriteLine($"Line: {line.Key}");
                            }

                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine("***************************************");
                }
            }
        }
    }
}