using System.Collections.Generic;
using System.Configuration;
using XmlParser;

namespace XmlParserManager
{
    public class XmlParserManager
    {
        private string _directory;
        private string _expression;
        //private int _threadsNum;
        
        public IEnumerable<string> Start()
        {
            Configure();
            var ca = FileQueueCreator.CreateFromDirectory(_directory);
            var str = new List<string>();

            var prs = new XmlParser.XmlParser();
            foreach (var fileInfo in ca)
            {
                str.AddRange(prs.Parse(fileInfo, _expression));
            }
            return str;
        }

        private void Configure()
        {
            _directory = ConfigurationManager.AppSettings.Get("directory");
            _expression = @"*/" + ConfigurationManager.AppSettings.Get("xPathExpression");
            //_threadsNum = int.Parse(ConfigurationManager.AppSettings.Get("threads"));
        }
    }
}
