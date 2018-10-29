using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFPodcastPlayer.Models
{
    [AddINotifyPropertyChangedInterface]
    public class PodcastSearchDetail
    {
        public string wrapperType { get; set; }
        public object artistId { get; set; }
        public object collectionId { get; set; }
        public string artistName { get; set; }
        public string collectionName { get; set; }
        public string collectionCensoredName { get; set; }
        public string artistViewUrl { get; set; }
        public string collectionViewUrl { get; set; }
        public string artworkUrl60 { get; set; }
        public string artworkUrl100 { get; set; }
        public double collectionPrice { get; set; }
        public string collectionExplicitness { get; set; }
        public int trackCount { get; set; }
        public string copyright { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public DateTime releaseDate { get; set; }
        public string primaryGenreName { get; set; }
        public string previewUrl { get; set; }
        public string description { get; set; }
        public int? amgArtistId { get; set; }
        public string kind { get; set; }
        public string trackId { get; set; }
        public string trackName { get; set; }
        public string trackCensoredName { get; set; }
        public string trackViewUrl { get; set; }
        public string artworkUrl30 { get; set; }
        public double? trackPrice { get; set; }
        public double? collectionHdPrice { get; set; }
        public double? trackHdPrice { get; set; }
        public string trackExplicitness { get; set; }
        public int? discCount { get; set; }
        public int? discNumber { get; set; }
        public int? trackNumber { get; set; }
        public int? trackTimeMillis { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public bool IsPlaying { get; set; }
    }

    public class PodcastSearchList
    {
        [JsonProperty(PropertyName = "resultCount")]
        public int PodcastSearchCount { get; set; }
        [JsonProperty(PropertyName = "results")]
        public List<PodcastSearchDetail> PodcastSearchDetailList { get; set; }
    }

}
