using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using XFPodcastPlayer.Models;
using XFPodcastPlayer.Services;

namespace XFPodcastPlayer.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {



        //var api = new ApiService();
        //var dataParse = new DataParse();

        //Task.Run(async() => {

        //    var stream = await api.GetRrsStreamAsync(_feedUrl);
        //    var result = dataParse.ParsePodcastRrsList(stream);

        //    //var results = await api.GetPodcastInfo("1369393780");


        //    //var result = dataParse.ParsePodcastObject(results);
        //    if (result != null)
        //    {
        //        var channel = result;
        //    }
        //});

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
