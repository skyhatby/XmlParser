﻿using System;

namespace XmlParserUI
{
    class Program
    {
        static void Main()
        {
            var c = new XmlParserManager.XmlParserManager(new XmlParser.XmlParser());
            var s = c.Start();
            foreach (var item in s)
            {
                Console.WriteLine(item.Key+" "+item.Count);
            }
            Console.ReadKey();
        }
    }
}
