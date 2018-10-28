using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using XFPodcastPlayer.ServicesInterfaces;

namespace XFPodcastPlayer.Droid.Services
{
    [Service]
    [IntentFilter(new[] { ActionPlay, ActionPause, ActionStop })]

    public class AudioStreamingService : Service, AudioManager.IOnAudioFocusChangeListener
    {
        //Actions
        public const string ActionPlay = "com.xamarin.action.PLAY";
        public const string ActionPause = "com.xamarin.action.PAUSE";
        public const string ActionStop = "com.xamarin.action.STOP";
       

        private MediaPlayer player;
        private AudioManager audioManager;
        private WifiManager wifiManager;
        private WifiManager.WifiLock wifiLock;
        private bool paused;
        private AudioAttributes mPlaybackAttributes { get; set; }

        private const int NotificationId = 1;


        public override void OnCreate()
        {
            base.OnCreate();
            audioManager = (AudioManager)GetSystemService(AudioService);
            wifiManager = (WifiManager)GetSystemService(WifiService);
        }


        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            
                Task.Run(async () => {

                    if (player != null)
                    {
                        var allExtrass = intent.Extras;
                        if (allExtrass != null)
                        {
                            var newAudio = allExtrass.Get("NewAudio");

                            if (!string.IsNullOrEmpty((string)allExtrass.Get("NewAudio")))
                            {
                                Stop();
                                await setPlayerDataSourse();
                            }
                        }
                        else
                        {
                            switch (intent.Action)
                            {
                                case ActionPlay: Play(); break;
                                case ActionStop: Stop(); break;
                                case ActionPause: Pause(); break;
                            }
                        }
                       

                    }
                    else
                    {
                        Play();
                    }

                });
            

            //Set sticky as we are a long running operation
            return StartCommandResult.Sticky;
        }

        private void IntializePlayer()
        {
            player = new MediaPlayer();

            mPlaybackAttributes = new AudioAttributes.Builder()
                                        .SetLegacyStreamType(Stream.Music)
                                        .SetUsage(AudioUsageKind.Media)
                                        .SetContentType(AudioContentType.Music)
                                        .Build();

            player.SetAudioAttributes(mPlaybackAttributes);

            player.SetWakeMode(ApplicationContext, WakeLockFlags.Partial);

            player.Prepared += (sender, args) => {

                player.Start();
                Console.WriteLine("start playback: " + MainActivity.AudioPath);
            };

            player.Completion += (sender, args) => Stop();

            player.Error += (sender, args) =>
            {
                Stop();
            };
        }

        private int notificationFired = 0;

        private async void Play()
        {

            if (paused && player != null)
            {
                paused = false;

                player.Start();
                if (notificationFired == 0)
                {
                    notificationFired++;
                    StartForeground();
                }
                return;
            }

            if (player == null)
            {
                IntializePlayer();
            }

            if (player.IsPlaying)
                return;

            try
            {
                await setPlayerDataSourse();
                AquireWifiLock();
                if (notificationFired == 0)
                {
                    notificationFired++;
                    StartForeground();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Unable to start playback: " + ex);
            }
        }

        private async Task setPlayerDataSourse()
        {
            try
            {
                await player.SetDataSourceAsync(MainActivity.AudioPath);

                var mFocusRequest = new AudioFocusRequestClass.Builder(AudioFocus.Gain)
                                   .SetAudioAttributes(mPlaybackAttributes)
                                   .SetAcceptsDelayedFocusGain(true)
                                   .SetWillPauseWhenDucked(true)
                                   .SetOnAudioFocusChangeListener(this)
                                   .Build();


                var focusResult = audioManager.RequestAudioFocus(mFocusRequest);
                if (focusResult != AudioFocusRequest.Granted)
                {
                    Console.WriteLine("Could not get audio focus");
                }

                player.PrepareAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Unable to start playback: " + ex);
            }
         
        }
       

        /// <summary>
        /// Local NItification about player being in use
        /// User return to the app if pressed
        /// </summary>
        private void StartForeground()
        {
            string NOTIFICATION_CHANNEL_ID = "com.danilkurkin.XFPodcastPlayer";
            string  channelName = "XFPodcastPlayer Background Service";

            var channel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, channelName, NotificationImportance.High)
            {
                LockscreenVisibility = NotificationVisibility.Public
            };

            //channel.setLoSetLockscreenVisibility(Notification.VISIBILITY_PRIVATE);

            NotificationManager manager = GetSystemService(Context.NotificationService) as NotificationManager;
            manager.CreateNotificationChannel(channel);

            var pendingIntent = PendingIntent.GetActivity(ApplicationContext, 0,
                           new Intent(ApplicationContext, typeof(MainActivity)),
                           PendingIntentFlags.UpdateCurrent);

            NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);
            Notification notification = notificationBuilder.SetOngoing(true)
                    .SetSmallIcon(Resource.Drawable.ic_local_not_play)
                    .SetContentTitle("Podcast Streaming")
                    .SetContentText(MainActivity.AudioTitle)
                    .SetContentIntent(pendingIntent)
                    .SetCategory(Notification.CategoryService)
                    .Build();
            notification.Flags |= NotificationFlags.OngoingEvent;
            StartForeground(NotificationId, notification);

        }

        private void Pause()
        {
            if (player == null)
                return;

            if (player.IsPlaying)
                player.Pause();

            StopForeground(true);
            paused = true;
        }

        private void Stop()
        {
            if (player == null)
                return;

            if (player.IsPlaying)
                player.Stop();

            if (notificationFired != 0)
            {
                notificationFired=0;
            }

            player.Reset();
            paused = false;
            StopForeground(true);
            ReleaseWifiLock();
        }

        /// <summary>
        /// Lock the wifi for streaming under lock screen
        /// </summary>
        private void AquireWifiLock()
        {
            if (wifiLock == null)
            {
                wifiLock = wifiManager.CreateWifiLock(WifiMode.Full, "wifi_lock");
            }
            wifiLock.Acquire();
        }

        /// <summary>
        /// Release the wifi lock if it is no needed
        /// </summary>
        private void ReleaseWifiLock()
        {
            if (wifiLock == null)
                return;

            wifiLock.Release();
            wifiLock = null;
        }

        /// <summary>
        /// Player cleanup - releasing resources
        /// </summary>
        public override void OnDestroy()
        {
            base.OnDestroy();
            if (player != null)
            {
                player.Release();
                player = null;
            }
        }

        /// <summary>
        /// If interrapted by other sound source, lower sound down 
        /// </summary>
        /// <param name="focusChange"></param>
        public void OnAudioFocusChange(AudioFocus focusChange)
        {
            switch (focusChange)
            {
                case AudioFocus.Gain:
                    if (player == null)
                        IntializePlayer();

                    if (!player.IsPlaying)
                    {
                        player.Start();
                        paused = false;
                    }

                    player.SetVolume(1.0f, 1.0f);
                    break;
                case AudioFocus.Loss:
                    Stop();
                    break;
                case AudioFocus.LossTransient:
                    Pause();
                    break;
                case AudioFocus.LossTransientCanDuck:
                    if (player.IsPlaying)
                        player.SetVolume(.1f, .1f);
                    break;

            }
        }
    }
}