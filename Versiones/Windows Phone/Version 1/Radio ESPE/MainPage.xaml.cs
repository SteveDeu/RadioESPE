using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Radio_ESPE.Resources;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Tasks;

namespace Radio_ESPE
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            BackgroundAudioPlayer.Instance.PlayStateChanged += new EventHandler(Instance_PlayStateChanged);
        }

        #region Button Click Event Handlers
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            {
                BackgroundAudioPlayer.Instance.Pause();
            }
            else
            {
                BackgroundAudioPlayer.Instance.Play();
            }
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("https://m.facebook.com/radioespe/");
            webBrowserTask.Show();
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("https://mobile.twitter.com/radioespe");
            webBrowserTask.Show();
        }

        private void btnInstagram_Click(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("https://www.instagram.com");
            webBrowserTask.Show();
        }

        private void btnYoutube_Click(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("https://m.youtube.com/channel/UCrxUvo-lwZTPeqrNX6cNxyQ");
            webBrowserTask.Show();
        }

        private void btnTemporizador_Click(object sender, EventArgs e)
        {
            //NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            //webBrowserTask.Uri = new Uri("http://www.google.com");
            webBrowserTask.Uri = new Uri("https://lh3.googleusercontent.com/-RKJEe4U7Ee0/VgNFN0lk3dI/AAAAAAAAPHY/RYyUW7WpaN8/w500-h500/5-chicas-hermosas-de-Gainax-que-debes-conocer-16-Animemx.gif");
            webBrowserTask.Show();
        }
        #endregion Button Click Event Handlers

        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {
                case PlayState.Playing:
                    playButton.Content = "pause";
                    break;
                case PlayState.Paused:
                case PlayState.Stopped:
                    playButton.Content = "play";
                    break;
            }

            if (null != BackgroundAudioPlayer.Instance.Track)
            {
                txtCurrentTrack.Text = BackgroundAudioPlayer.Instance.Track.Title + " by " + BackgroundAudioPlayer.Instance.Track.Artist;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            {
                playButton.Content = "pause";
                txtCurrentTrack.Text = BackgroundAudioPlayer.Instance.Track.Title + " by " + BackgroundAudioPlayer.Instance.Track.Artist;
            }
            else
            {
                playButton.Content = "play";
                txtCurrentTrack.Text = "";
            }
        }

        private void btnPeticiones_Click(object sender, RoutedEventArgs e)
        {
            if (txtPeticion.Text.Length <= 0)
            {
                MessageBox.Show("Ingresa datos °<° ");
                txtPeticion.Focus();
            }
            else
            {
                MessageBox.Show("Gracias por tu sugerencia! :v");
                txtPeticion.Text = "";
            }
        }
    }
}