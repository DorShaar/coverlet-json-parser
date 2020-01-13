using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CoverletExtension
{
    public class Method
    {
        public string MethodName { get; }
        public List<LineInfo> Lines = new List<LineInfo>();
        public bool IsCovered => Lines.All(line => line.LineUsages > 0);

        public Method(string methodName, JProperty methodToken)
        {
            MethodName = methodName;
            CreateFromJToken(methodToken);
        }

        private void CreateFromJToken(JProperty methodToken)
        {
            foreach (JObject methodTokens in methodToken.Children())
            {
                JObject methodLinesObject = methodTokens["Lines"] as JObject;
                foreach (JProperty methodLinesProperty in methodLinesObject.Children())
                {
                    AddMethodLinesFromJToken(methodLinesProperty);
                }
            }
        }

        private void AddMethodLinesFromJToken(JProperty methodLinesToken)
        {
            foreach (JValue lineValue in methodLinesToken.Children())
            {
                Lines.Add(new LineInfo(
                    int.Parse(methodLinesToken.Name),
                    int.Parse(lineValue.Value.ToString())));
            }
        }
    }
}