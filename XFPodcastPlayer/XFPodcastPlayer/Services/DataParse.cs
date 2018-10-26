using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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

        public List<PodcastTop10> ParseTop10Rrs(Stream rrsStream)
        {
            try
            {
                var xml = XDocument.Load(rrsStream);
                var podcastItemsList = from item in xml.Descendants("item") 
                                              select new PodcastTop10()
                                              {
                                                  Title = item.Element("title").Value,
                                                  Link = item.Element("link").Value,
                                                  Description = item.Element("description").Value,
                                                  Category = (from cat in item.Elements("category").ToList() select cat.Value).ToList(),
                                                  PublicationDate = DateTime.Parse(item.Element("pubDate")?.Value)

                                              };
                 

                return podcastItemsList.ToList();
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
               
                var xml = XDocument.Load(rrsStream);
                XNamespace ns = "http://www.itunes.com/dtds/podcast-1.0.dtd";

                var podcastItemsList = from item in xml.Descendants("item")
                        select new PodcastPlayItem()
                        {
                            Title = item.Element("title").Value,
                            Description = item.Element("description").Value,
                            SubTitle = item.Element(ns + "subtitle").Value,
                            AudioPath = item.Element("enclosure").Value,
                            PublicationDate = DateTime.Parse(item.Element("pubDate")?.Value)
                        };

                return podcastItemsList.ToList();
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
