using System;
using System.Collections.Generic;
using System.Text;

namespace XFPodcastPlayer
{
    public static class Constants
    {
        public const string PodcastLookup = "https://itunes.apple.com/lookup?id={0}";
        public const string PodcastTop10Url = "https://rss.itunes.apple.com/api/v1/us/podcasts/top-podcasts/all/10/explicit.rss";

        public static readonly TimeSpan ServerTimeout = TimeSpan.FromSeconds(30);
    }
}
