using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoverletExtension
{
    public class CoverletJsonParser
    {
        public List<CoverageResult> Parse(string jsonFilePath)
        {
            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine($"No such file {jsonFilePath}");
                return null;
            }

            string jsonString = File.ReadAllText(jsonFilePath);

            JObject jsonObject = JObject.Parse(jsonString);

            List<CoverageResult> coverageResults = new List<CoverageResult>();

            foreach (JProperty moduleProperty in jsonObject.Children())
            {
                coverageResults.Add(new CoverageResult(moduleProperty));
            }

            return coverageResults;
        }
    }
}