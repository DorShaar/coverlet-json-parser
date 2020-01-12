using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace CoverletExtension
{
    public class CoverletJsonParser
    {
        public CoverageResult Parse(string jsonFilePath)
        {
            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine($"No such file {jsonFilePath}");
                return new CoverageResult();
            }

            string jsonString = File.ReadAllText(jsonFilePath);

            JObject jsonObject = JObject.Parse(jsonString);

            CoverageResult coverageResult = new CoverageResult();

            foreach (JProperty moduleProperty in jsonObject.Children())
            {
                coverageResult.AddModuleFromJToken(moduleProperty);
            }

            return coverageResult;
        }
    }
}