using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoverletExtension
{
    public class Document
    {
        public string DocumentPath { get; }
        public List<Class> Classes { get; } = new List<Class>();
        public bool IsCovered => Classes.All(@class => @class.IsCovered);

        public Document(string documentPath, JProperty documentToken)
        {
            DocumentPath = documentPath;
            CreateDocumentFromJToken(documentToken);
        }

        private void CreateDocumentFromJToken(JProperty documentToken)
        {
            foreach (JObject classObject in documentToken.Children())
            {
                foreach (JProperty classProperty in classObject.Children())
                {
                    string className = Path.GetFileName(classProperty.Name);
                    Classes.Add(new Class(className, classProperty));
                }
            }
        }
    }
}