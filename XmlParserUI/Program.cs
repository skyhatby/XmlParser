using System;
using System.Linq;

namespace XmlParserUI
{
    class Program
    {
        static void Main()
        {
            
            var c = new XmlParserManager.XmlParserManager();
            var s = c.Start();
            Console.WriteLine(s.Skip(1).FirstOrDefault());
            
            Console.ReadKey();
        }
    }
}
