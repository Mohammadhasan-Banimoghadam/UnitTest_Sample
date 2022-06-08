using System.Collections.Generic;
using System.Linq;

namespace UnitTest_Sample.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
                return context.Videos.Where(x => !x.IsProcessed).ToList();
            }
        }
    }
}
