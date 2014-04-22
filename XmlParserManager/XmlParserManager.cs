using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using XmlParser;

namespace XmlParserManager
{
    public class XmlParserManager
    {
        private string _directory;
        private string _expression;
        private int _threadsNum;

        

        public IEnumerable<string> Start()
        {
            Configure();
            ThreadPool.SetMaxThreads(_threadsNum, _threadsNum);
            var ca = FileQueueCreator.CreateFromDirectory(_directory);
            var str = new List<string>();

            var prs = new XmlParser.XmlParser();
            foreach (var fileInfo in ca)
            {
                var info = fileInfo;
                var task = Task.Run(() => prs.Parse(info,_expression));
                str.AddRange(task.Result);
            }
            return str;
        }

        private void Configure()
        {
            _directory = ConfigurationManager.AppSettings.Get("directory");
            _expression = @"*/" + ConfigurationManager.AppSettings.Get("xPathExpression");
            _threadsNum = int.Parse(ConfigurationManager.AppSettings.Get("threads"));
        }
    }
}
