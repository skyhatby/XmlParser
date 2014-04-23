using System.Collections.Generic;
using System.IO;

namespace XmlParser
{
    public interface IXmlParser
    {
        List<string> Parse(FileInfo fileInfo, string xPathExpression);
    }
}