namespace YouTubeClone.Models
{

    public class SearchResultModel
    {
        public List<Thumbnail> thumbs { get; set; }
        public List<VideoSearch> vidSearch { get; set; }
        
    }
    public class Thumbnail
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class VideoSearch
    {

        public string ChannelName { get; set; }
        public string Description { get; set; }
        public string LengthText { get; set; }
        public string PublishedTimeText { get; set; }
        public string Title { get; set; }
        public string ViewCountText { get; set; }
    }
}
