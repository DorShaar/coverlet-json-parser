using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoverletExtension
{
    public class Module
    {
        public string ModuleName { get; }
        public List<Document> Documents { get; } = new List<Document>();
        public bool IsCovered => Documents.All(document => document.IsCovered);

        public Module(string moduleName, JProperty documentToken)
        {
            ModuleName = moduleName;
            CreateDocumentFromJToken(documentToken);
        }

        private void CreateDocumentFromJToken(JProperty moduleToken)
        {
            foreach (JObject documentObject in moduleToken.Children())
            {
                foreach (JProperty documentProperty in documentObject.Children())
                {
                    string documentName = Path.GetFileName(documentProperty.Name);
                    Documents.Add(new Document(documentName, documentProperty));
                }
            }
        }
    }
}