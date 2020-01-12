using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CoverletExtension
{
    public class Class
    {
        public string ClassName { get; }
        public Dictionary<string, Method> Methods { get; } = new Dictionary<string, Method>();

        public Class(string className)
        {
            ClassName = className;
        }

        public void AddMethodFromJToken(JProperty methodToken)
        {
            string methodName = methodToken.Name;

            Method method = new Method(methodName);
            foreach (JObject methodTokens in methodToken.Children())
            {
                JObject methodLinesObject = methodTokens["Lines"] as JObject;
                foreach (JProperty methodLinesProperty in methodLinesObject.Children())
                {
                    method.AddMethodLinesFromJToken(methodLinesProperty);
                }
            }

            Methods.Add(methodName, method);
        }
    }
}