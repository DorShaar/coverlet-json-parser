using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CoverletExtension
{
    public class Class
    {
        public string ClassName { get; }
        public List<Method> Methods { get; } = new List<Method>();
        public bool IsCovered => Methods.All(method => method.IsCovered);

        public Class(string className, JProperty classToken)
        {
            ClassName = className;
            CreateClassFromJToken(classToken);
        }

        private void CreateClassFromJToken(JProperty classToken)
        {
            foreach (JObject methodToken in classToken.Children())
            {
                foreach (JProperty methodProperty in methodToken.Children())
                {
                    Methods.Add(new Method(methodProperty.Name, methodProperty));
                }
            }
        }
    }
}