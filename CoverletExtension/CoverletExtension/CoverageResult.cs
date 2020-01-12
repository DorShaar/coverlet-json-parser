using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CoverletExtension
{
    public class CoverageResult
    {
        public Dictionary<string, Module> Modules = new Dictionary<string, Module>();

        public void AddModuleFromJToken(JProperty moduleProperty)
        {
            string moduleName = moduleProperty.Name;

            Module module = new Module(moduleName);
            foreach (JObject documentObject in moduleProperty.Children())
            {
                foreach (JProperty documentProperty in documentObject.Children())
                {
                    module.AddDocumentFromJToken(documentProperty);
                }
            }

            Modules.Add(moduleName, module);
        }
    }
}