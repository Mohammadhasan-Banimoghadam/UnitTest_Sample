using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Mocking;
using Xunit;

namespace UnitTest_Sample.UnitTest.Mocking
{
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private readonly InstallerHelper _installerHelper;

        public InstallerHelperTests()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Fact]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _fileDownloader.Setup(fd =>
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.False(result);
        }

        [Fact]
        public void DownloadInstaller_DownloadCompleted_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.True(result);
        }
    }
}
