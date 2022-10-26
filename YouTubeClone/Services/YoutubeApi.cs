using Amazon.ElasticTranscoder.Model;
using Newtonsoft.Json;
using YouTubeClone.Models;
using static YouTubeClone.Services.VideoSearchResults;

namespace YouTubeClone.Services
{
    public class YoutubeApi
    {

        public YoutubeApi() { }

        public List<SearchResultModel> GetVideoInfo(string searchTerm)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://youtube-search-and-download.p.rapidapi.com/search?query={searchTerm}&next=EogDEgVoZWxsbxr-AlNCU0NBUXRaVVVoeldFMW5iRU01UVlJQkMyMUlUMDVPWTFwaWQwUlpnZ0VMWW1VeE1rSkROWEJSVEVXQ0FRdFZNMEZUYWpGTU5sOXpXWUlCQzJaaGVrMVRRMXBuTFcxM2dnRUxaV3hrWldGSlFYWmZkMFdDQVExU1JGbFJTSE5ZVFdkc1F6bEJnZ0VMT0hwRVUybHJRMmc1Tm1PQ0FRc3pOMFU1VjNORWJVUmxaNElCQzJGaFNXcHpPRXN6YjFsdmdnRUxaMmRvUkZKS1ZuaEdlRldDQVF0clN6UXlURnB4VHpCM1FZSUJDME42VHpOaFNXVXdVbkJ6Z2dFTFNVNHdUMk5WZGtkaU5qQ0NBUXRSYTJWbGFGRTRSRjlXVFlJQkMyWk9NVU41Y2pCYVN6bE5nZ0VMZEZac1kwdHdNMkpYU0RpQ0FRdGZSQzFGT1Rsa01XSk1TWUlCQzJoQlUwNVRSSFZOY2pGUmdnRUxkREEzTVZkdE5EVnhWMDAlM0QYgeDoGCILc2VhcmNoLWZlZWQ%253D&hl=en&gl=US&upload_date=t&type=v&duration=s&features=li%3Bhd&sort=v"),
				Headers =
				{
					{ "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
					{ "X-RapidAPI-Host", "youtube-search-and-download.p.rapidapi.com" },
				},
			};

			using (var response = client.SendAsync(request).Result)
			{
				response.EnsureSuccessStatusCode();
				var body = response.Content.ReadAsStringAsync().Result;

				var vidInfo = JsonConvert.DeserializeObject<VideoSearchResults>(body);
				var searchResultModel = new List<SearchResultModel>();

				

				//VIDEO OBJECT
				foreach (var item in vidInfo.contents)
				{
					foreach(var viddy in searchResultModel)
                    {
						foreach( var vidItem in viddy.vidSearch)
                        {
							vidItem.ChannelName = item.video.channelName;
							vidItem.Title = item.video.title;
							vidItem.Description = item.video.description;
							vidItem.PublishedTimeText = item.video.publishedTimeText;
							vidItem.LengthText = item.video.lengthText;
                        }
                    }
								

					//THUMBNAIL OBJECT

					foreach (var thumb in item.video.thumbnails)
					{
						foreach (var thing in searchResultModel)
						{
							foreach (var thumbItem in thing.thumbs)
							{
								thumbItem.Url = thumb.url;
								thumbItem.Height = thumb.height;
								thumbItem.Width = thumb.width;
							}
						}
						
					}
				}

				

				return searchResultModel;
				
			}


		}

    }
}
