using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PodCastView : ContentPage
	{   
		public PodCastView ()
		{
			InitializeComponent ();

            BindingContext = ListaPodcasts();
        }

        private async Task<List<Podcast>> ListaPodcasts()
        {
            ActIndicator.IsVisible = true;

            List<Podcast> Podcasts = await PodcastService.GetListaPodcasts();
            LstPodcast.ItemsSource = Podcasts;
            ActIndicator.IsVisible = false;

            return Podcasts;
        }

        private void LstPodcast_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LstPodcast.SelectedItem = false;
        }

        private async void BtnPlay_OnClicked(object sender, EventArgs e)
        {
            Button btnPlay = (Button)sender;            
            Podcast podcast = (Podcast)btnPlay.CommandParameter;

            var mediaFile = new MediaFile
            {
                Type = MediaFileType.Audio,
                Availability = ResourceAvailability.Remote,
                Url = "http://" + podcast.link,
            };
            await CrossMediaManager.Current.Play(mediaFile);
        }

        private async void BtnPause_OnClicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Pause();
        }
    }
}