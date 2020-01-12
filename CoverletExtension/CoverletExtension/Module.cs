using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace CoverletExtension
{
    public class Module
    {
        public string ModuleName { get; }
        public Dictionary<string, Document> Documents { get; } = new Dictionary<string, Document>();

        public Module(string moduleName)
        {
            ModuleName = moduleName;
        }

        public void AddDocumentFromJToken(JProperty documentToken)
        {
            string documentName = Path.GetFileName(documentToken.Name);

            Document document = new Document(documentName);
            foreach (JObject classObject in documentToken.Children())
            {
                foreach (JProperty classProperty in classObject.Children())
                {
                    document.AddClassFromJToken(classProperty);
                }
            }

            Documents.Add(documentName, document);
        }
    }
}