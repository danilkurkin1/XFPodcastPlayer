using PropertyChanged;
using System;


namespace XFPodcastPlayer.Models
{
    [AddINotifyPropertyChangedInterface]
    public class PodcastPlayItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AudioPath { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsPlaying {get;set;}
    }
}
