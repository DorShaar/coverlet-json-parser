using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CoverletExtension
{
    public class CoverageResult
    {
        public List<Module> Modules = new List<Module>();
        public bool IsCovered => Modules.All(module => module.IsCovered);

        public CoverageResult(JProperty moduleProperty)
        {
            Modules.Add(new Module(moduleProperty.Name, moduleProperty));
        }
    }
}