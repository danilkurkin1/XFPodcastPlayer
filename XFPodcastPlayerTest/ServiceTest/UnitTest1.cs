using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.Services;
using Xunit;

namespace XFPodcastPlayerTest
{
    public class DataParseTest
    {
        public DataService dataParse { get; set; } 
        public ApiService apiService { get; set; }

        [Fact]
        public void ParseTop10()
        {
            //Arrange
            InitParcer();
            var stream = ReadFile("top-podcasts.rss");

            //Act
            var result = dataParse.ParseTop10Rrs(stream);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);

        }

        [Fact]
        public void ParsePodcastRrsList()
        {
            //Arrange
            InitParcer();
            var stream = ReadFile("example-podcast.rss");

            //Act
            var result = dataParse.ParsePodcastPlayList(stream);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);

        }

        [Fact]
        public async Task ParsePodcastHtmlList()
        {
            //Arrange
            InitParcer();
            var stream = await apiService.GetRrsStreamAsync("http://feeds.feedburner.com/pretty-basic");

              //Act
            var result = dataParse.ParsePodcastPlayList(stream);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);

        }

        [Fact]
        public void GetUserId()
        {
            //Arrange
            InitParcer();
            string url = "https://itunes.apple.com/us/podcast/the-habitat/id1369393780?mt=2";

            //Act
            var result = dataParse.GetPodcastId(url);

            //Assert
            Assert.Equal("1369393780", result);
        }

        ////n
        //[Fact]
        //public async Task ParsePodcastObject()
        //{
        //    //Arrange
        //    InitParcer();
        //    var fakeHttpResponse = getFakeHttpMessage("podcast.json");

        //    //Act
        //    PodcastList result = await dataParse.ParsePodcastObject(fakeHttpResponse);

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.True(result.PodcastDetailsCount == 1);

        //}




        private void InitParcer()
        {
            dataParse = new DataService();
            apiService = new ApiService();
        }


        private Stream  ReadFile(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"TestFiles/", fileName);

            Stream fs = File.OpenRead(path);

            return fs;
        }

    }
}
