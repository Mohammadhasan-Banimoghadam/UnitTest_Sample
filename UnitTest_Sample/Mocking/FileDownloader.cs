using System.Net;

namespace UnitTest_Sample.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string customerName, string installerName, string fileName);
    }

    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string customerName, string installerName, string fileName)
        {
            var client = new WebClient();
            client.DownloadFile($"http://example.com/{customerName}/{installerName}", fileName);
        }
    }
}
