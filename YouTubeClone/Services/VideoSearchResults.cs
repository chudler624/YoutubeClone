namespace YouTubeClone.Services
{
        public class VideoSearchResults
        {
            public List<Content> contents { get; set; }
            public string estimatedResults { get; set; }
            public string next { get; set; }
        }
   
    
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Content
        {
            public Video video { get; set; }
        }


        public class Thumbnail
        {
            public int height { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }

        public class Video
        {
            public string channelId { get; set; }
            public string channelName { get; set; }
            public string lengthText { get; set; }
            public string publishedTimeText { get; set; }
            public List<Thumbnail> thumbnails { get; set; }
            public string title { get; set; }
            public string videoId { get; set; }
            public string viewCountText { get; set; }
            public string description { get; set; }
        }




    
}
