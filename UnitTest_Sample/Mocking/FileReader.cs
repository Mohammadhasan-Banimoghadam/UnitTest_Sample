using System.IO;

namespace UnitTest_Sample.Mocking
{
    public interface IFileReader
    {
        string Read(string path);
    }
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
