using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace CoverletExtension
{
    public class Document
    {
        public string DocumentPath { get; }
        public Dictionary<string, @Class> Classes { get; } = new Dictionary<string, Class>();

        public Document(string documentPath)
        {
            DocumentPath = documentPath;
        }

        public void AddClassFromJToken(JProperty classToken)
        {
            string className = Path.GetFileName(classToken.Name);
            @Class @class = new @Class(className);

            foreach (JObject methodToken in classToken.Children())
            {
                foreach (JProperty methodProperty in methodToken.Children())
                {
                    @class.AddMethodFromJToken(methodProperty);
                }
            }

            Classes.Add(className, @class);
        }
    }
}