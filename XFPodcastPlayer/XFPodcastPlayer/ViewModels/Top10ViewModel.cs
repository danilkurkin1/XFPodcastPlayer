﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFPodcastPlayer.Models;
using XFPodcastPlayer.Services;
using XFPodcastPlayer.ServicesInterfaces;
using XFPodcastPlayer.Views;

namespace XFPodcastPlayer.ViewModels
{
    public class Top10ViewModel : BaseViewModel
    {
        public ObservableCollection<PodcastTop10> Top10Items { get; set; }
        public Command LoadItemsCommand { get; set; }
       
       

        public Top10ViewModel()
        {
            Top10Items = new ObservableCollection<PodcastTop10>();
            LoadItemsCommand = new Command(async () =>
            {
                await Task.Run(async () => await ExecuteLoadItemsCommand());
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                await App.PopupService.StartLoading();
                var stream = await ApiService.GetRrsStreamAsync(Constants.PodcastTop10Url);
                var lookupResult = DataService.ParseTop10Rrs(stream);
                await App.PopupService.StopLoading();
                Top10Items.Clear();

                foreach (var result in lookupResult)
                {
                    Top10Items.Add(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

            }
        }

        public ICommand OpenPodcastDetailView => new Command(async(selectedPodcast) =>
        {
            var podcastDetails = await GetPodcastDetails((PodcastTop10)selectedPodcast);
            if (podcastDetails != null)
            {  
                // TabletView handle this even separetley
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    await Navigation.PushAsync(new PodcastDetailView(new PodcastDetailViewModel(podcastDetails)));
                }
            }
            else
            {
                //error show popup
            }
        });


        public async Task<PodcastDetail> GetPodcastDetails(PodcastTop10 podcastTop10)
        {
            await App.PopupService.StartLoading();
            var podcastId = DataService.GetPodcastId(podcastTop10.Link);
            var httpResponse = await ApiService.GetPodcastInfo(podcastId);
            var result = DataService.ParsePodcastObject(httpResponse).Result;
            await App.PopupService.StopLoading();
            if (result.PodcastDetailsCount > 0)
            {
                return result.PodcastDetailsList[0];
            }
            else
            {
                return null;
            }
        }
    }
}