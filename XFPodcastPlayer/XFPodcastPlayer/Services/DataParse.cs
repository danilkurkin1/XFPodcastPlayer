using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.ServicesInterfaces;

namespace XFPodcastPlayer.Services
{
    public class DataParse: IDataParse
    {

        public PodcastTop10 ParseTop10Rrs(Stream rrsStream)
        {
            try
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(PodcastTop10));
                return (PodcastTop10)serializer.Deserialize(rrsStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

        public List<PodcastPlayItem> ParsePodcastRrsList(Stream rrsStream)
        {
            try
            {
                var PodcastItemsList = new List<PodcastPlayItem>();
                var xml = XDocument.Load(rrsStream);
                XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";
                foreach (var item in xml.Descendants("item"))
                {
                    var title = item.Element("title").Value;
                    var subtitle = item.Element(ns + "subtitle").Value;
                    var audioPath = item.Element("enclosure").Value;

                    PodcastItemsList.Add(new PodcastPlayItem(title, subtitle, audioPath));
                }
                return PodcastItemsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

        public async Task<PodcastList> ParsePodcastObject(HttpResponseMessage message)
        {
            try
            {
                if (message.IsSuccessStatusCode)
                {
                    var content = await message.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<PodcastList>(content);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

    }
}
