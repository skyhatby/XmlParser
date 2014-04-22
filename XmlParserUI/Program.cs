using System;

namespace XmlParserUI
{
    class Program
    {
        static void Main()
        {
            var c = new XmlParserManager.XmlParserManager();
            var s = c.Start();
            foreach (var item in s)
            {
                Console.WriteLine(item.Item1+" "+item.Item2);
            }
            Console.ReadKey();
        }
    }
}
