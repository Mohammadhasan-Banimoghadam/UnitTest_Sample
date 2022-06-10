using System.Net;

namespace UnitTest_Sample.Mocking
{
    public class InstallerHelper
    {
        private string _fileName;
        private readonly IFileDownloader _fileDownloader;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownloadFile(customerName, installerName, _fileName);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
