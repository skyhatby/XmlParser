using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace XmlParser
{
    public class XmlParser
    {
        public static void Parse(FileInfo fileInfo, List<string> str, string xPathExpression)
        {
            var tr = new XmlTextReader(fileInfo.FullName); 
            var doc = new XPathDocument(tr);
            var nav = doc.CreateNavigator();
            var ex = nav.Compile(xPathExpression);
            str.AddRange(from object item in nav.Select(ex) select item.ToString());
        }
    }
}
