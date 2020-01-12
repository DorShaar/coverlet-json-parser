using System;

namespace CoverletExtension
{
    public class CoverageMissPrinter
    {
        public void Print(CoverageResult coverageResult)
        {
            foreach (var module in coverageResult.Modules)
            {
                Console.WriteLine($"Module: {module.Key}");

                foreach (Document document in module.Value.Documents)
                {
                    Console.WriteLine($"Document: {document.DocumentPath}");

                    foreach (Class @class in document.Classes)
                    {
                        Console.WriteLine($"Class: {@class.ClassName}");

                        foreach (Method method in @class.Methods)
                        {
                            Console.WriteLine($"Method: {method.MethodName}");
                        
                            foreach (LineInfo lineInfo in method.Lines)
                            {
                                if (lineInfo.LineUsages == 0)
                                    Console.WriteLine($"Line: {lineInfo.LineNumber}");
                            }

                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine("*********************************************************");
                }
            }
        }
    }
}