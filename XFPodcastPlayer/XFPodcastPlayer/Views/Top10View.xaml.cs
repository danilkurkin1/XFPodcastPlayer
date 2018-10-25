using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace XFPodcastPlayer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Top10View : ContentPage
    {
        //Top10ViewModel viewModel;

        public Top10View()
        {
            InitializeComponent();
        
        }

       

        protected override void OnAppearing()
        {
           
        }
    }
}