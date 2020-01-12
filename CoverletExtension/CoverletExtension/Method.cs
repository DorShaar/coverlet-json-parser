using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CoverletExtension
{
    public class Method
    {
        public string MethodName { get; }
        public List<LineInfo> Lines = new List<LineInfo>();

        public Method(string methodName)
        {
            MethodName = methodName;
        }

        public void AddMethodLinesFromJToken(JProperty methodLinesToken)
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