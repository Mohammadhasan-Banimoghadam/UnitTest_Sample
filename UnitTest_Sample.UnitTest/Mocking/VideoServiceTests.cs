using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using UnitTest_Sample.Mocking;
using Moq;

namespace UnitTest_Sample.UnitTest.Mocking
{
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;

        public VideoServiceTests()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Fact]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.Contains("error", result, StringComparison.OrdinalIgnoreCase);
        }
    }
}
