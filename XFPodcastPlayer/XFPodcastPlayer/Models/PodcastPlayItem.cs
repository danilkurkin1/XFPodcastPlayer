using System;
using System.Collections.Generic;
using System.Text;

namespace XFPodcastPlayer.Models
{
    public class PodcastPlayItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AudioPath { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
