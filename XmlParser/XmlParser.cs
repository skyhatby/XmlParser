using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace XmlParser
{
    public class XmlParser : IXmlParser
    {
        public List<string> Parse(FileInfo fileInfo, string xPathExpression)
        {
            var str = new List<string>();
            var tr = new XmlTextReader(fileInfo.FullName) { Namespaces = false };
            var doc = new XPathDocument(tr);
            var nav = doc.CreateNavigator();
            var ex = nav.Compile(xPathExpression);
            str.AddRange(from object item in nav.Select(ex) select item.ToString());
            if (str.Count == 0) str.Add("N/A");
            return str;
        }
    }
}
