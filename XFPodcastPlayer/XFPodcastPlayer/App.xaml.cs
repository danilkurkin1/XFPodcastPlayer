using Ninject;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPodcastPlayer.Services;
using XFPodcastPlayer.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFPodcastPlayer
{
    public partial class App : Application
    {
        public static IKernel Container { get; set; }

        public App()
        {
            InitializeComponent();
                      
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
