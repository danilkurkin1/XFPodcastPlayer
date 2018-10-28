using System;
using System.Collections.Generic;
using System.Text;

namespace XFPodcastPlayer.ServicesInterfaces
{
    public interface IAudioStreamingService
    {
        void InitAndPlay(string AudioPath, string AudioTitle);
        void Play();
        void Pause();
    }
}
