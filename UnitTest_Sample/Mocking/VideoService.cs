using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;

namespace UnitTest_Sample.Mocking
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }

    public class VideoService
    {
        private readonly IFileReader _fileReader;

        public VideoService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);

            if (video == null)
                return "Error parsing the video.";

            return video.Title;
        }
    }


}
