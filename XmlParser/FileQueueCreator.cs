using System.Collections.Generic;
using System.IO;

namespace XmlParser
{
    public class FileQueueCreator
    {
        public static IEnumerable<FileInfo> CreateFromDirectory(string directoryPath)
        {
            var dir = new DirectoryInfo(directoryPath);
            var files = new Queue<FileInfo>();
            foreach (var file in dir.GetFiles("*.xml", SearchOption.AllDirectories))
            {
                files.Enqueue(file);
            }
            return files;
        }
    }
}
