using System;
using System.Collections.Generic;
using System.Text;

namespace XFPodcastPlayer.Models
{
    public class PodcastPlayItem
    {
        public PodcastPlayItem(string title, string subTitle, string audioPath)
        {
            Title = title;
            SubTitle = subTitle;
            AudioPath = audioPath;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string AudioPath { get; set; }

    }
}
