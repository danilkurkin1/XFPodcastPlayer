using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using XFPodcastPlayer.ServicesInterfaces;

namespace XFPodcastPlayer.Services
{
    public class NinjectDemoModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDataParse>().To<DataParse>();
            this.Bind<IApiService>().To<ApiService>();
        }
    }
}
