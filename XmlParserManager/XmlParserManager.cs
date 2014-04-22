using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

        public IEnumerable<Tuple<string,int>> Start()
        {
            Configure();
            var ca = FileQueueCreator.CreateFromDirectory(_directory);
            var str = new List<string>();
            
            var prs = new XmlParser.XmlParser();
            foreach (var fileInfo in ca)
            {
                var info = fileInfo;
                var task = Task.Run(() => prs.Parse(info,_expression));
                str.AddRange(task.Result);
            }
            return str.GroupBy(x => x)
                .Select(group => Tuple.Create(group.Key,group.Count()))
                .OrderByDescending(x => x.Item2).ThenByDescending(x=>x.Item1);
        }

        private void Configure()
        {
            GetConfigs();
            ThreadPool.SetMaxThreads(_threadsNum, _threadsNum);
        }

        private void GetConfigs()
        {
            _directory = ConfigurationManager.AppSettings.Get("directory");
            _expression = @"*/" + ConfigurationManager.AppSettings.Get("xPathExpression");
            _threadsNum = int.Parse(ConfigurationManager.AppSettings.Get("threads"));
        }
    }
}
