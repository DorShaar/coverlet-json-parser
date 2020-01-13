using System;
using System.Collections.Generic;

namespace CoverletExtension
{
    public class CoverageMissPrinter
    {
        public void Print(IEnumerable<CoverageResult> coverageResults)
        {
            foreach(CoverageResult coverageResult in coverageResults)
            {
                if (coverageResult.IsCovered)
                    continue;

                PrintAllUncoveredModules(coverageResult.Modules);
            }
        }

        private void PrintAllUncoveredModules(IEnumerable<Module> modules)
        {
            foreach (Module module in modules)
            {
                if (module.IsCovered)
                    continue;

                Console.WriteLine($"Module: {module.ModuleName}");
                PrintAllUncoveredDocuments(module.Documents);
            }
        }

        private void PrintAllUncoveredDocuments(IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.IsCovered)
                    continue;

                Console.WriteLine($"Document: {document.DocumentPath}");
                PrintAllUncoveredClasses(document.Classes);
            }
        }

        private void PrintAllUncoveredClasses(IEnumerable<Class> classes)
        {
            foreach (Class @class in classes)
            {
                if (@class.IsCovered)
                    continue;

                Console.WriteLine($"Class: {@class.ClassName}");
                PrintAllUncoveredMethods(@class.Methods);

                Console.WriteLine("*********************************************************");
            }
        }

        private void PrintAllUncoveredMethods(IEnumerable<Method> methods)
        {
            foreach (Method method in methods)
            {
                if (method.IsCovered)
                    continue;

                Console.WriteLine($"Method: {method.MethodName}");
                PrintAllUncoveredLines(method.Lines);
                Console.WriteLine();
            }
        }

        private void PrintAllUncoveredLines(IEnumerable<LineInfo> lines)
        {
            foreach (LineInfo lineInfo in lines)
            {
                if (lineInfo.LineUsages == 0)
                    Console.WriteLine($"Line: {lineInfo.LineNumber}");
            }
        }
    }
}