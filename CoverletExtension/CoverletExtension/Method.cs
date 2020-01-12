using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CoverletExtension
{
    public class Method
    {
        public string MethodName { get; }

        public SortedDictionary<int, int> Lines = new SortedDictionary<int, int>();

        public Method(string methodName)
        {
            MethodName = methodName;
        }

        public void AddMethodLinesFromJToken(JProperty methodLinesToken)
        {
            foreach (JValue lineValue in methodLinesToken.Children())
            {
                Lines.Add(int.Parse(methodLinesToken.Name), int.Parse(lineValue.Value.ToString()));
            }
        }
    }
}