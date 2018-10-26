using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XFPodcastPlayer.Models
{
   

   
    public class PodcastTop10
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<string> Category { get; set; }

    }

}
