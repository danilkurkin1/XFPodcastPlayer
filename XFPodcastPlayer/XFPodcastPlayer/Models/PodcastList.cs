using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFPodcastPlayer.Models
{
   
    public class PodcastDetail
    {
        public string wrapperType { get; set; }
        public string kind { get; set; }
        public string artistId { get; set; }
        public int collectionId { get; set; }
        public int trackId { get; set; }
        public string artistName { get; set; }
        public string collectionName { get; set; }
        public string trackName { get; set; }
        public string collectionCensoredName { get; set; }
        public string trackCensoredName { get; set; }
        public string artistViewUrl { get; set; }
        public string collectionViewUrl { get; set; }
        public string feedUrl { get; set; }
        public string trackViewUrl { get; set; }
        public string artworkUrl30 { get; set; }
        public string artworkUrl60 { get; set; }
        public string artworkUrl100 { get; set; }
        public double collectionPrice { get; set; }
        public double trackPrice { get; set; }
        public int trackRentalPrice { get; set; }
        public int collectionHdPrice { get; set; }
        public int trackHdPrice { get; set; }
        public int trackHdRentalPrice { get; set; }
        public DateTime releaseDate { get; set; }
        public string collectionExplicitness { get; set; }
        public string trackExplicitness { get; set; }
        public int trackCount { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string primaryGenreName { get; set; }
        public string contentAdvisoryRating { get; set; }
        public string artworkUrl600 { get; set; }
        public List<string> genreIds { get; set; }
        public List<string> genres { get; set; }
    }

    public class PodcastList
    {
        [JsonProperty(PropertyName = "resultCount")]
        public int PodcastDetailsCount { get; set; }
        [JsonProperty(PropertyName = "results")]
        public List<PodcastDetail> PodcastDetailsList { get; set; }
    }
}
