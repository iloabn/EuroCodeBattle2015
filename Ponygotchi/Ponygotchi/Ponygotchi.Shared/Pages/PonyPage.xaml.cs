using Ponygotchi.GameLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Ponygotchi.Utils;
using System.Threading.Tasks;
using Windows.System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ponygotchi.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PonyPage : Page
    {
        int count = 0;
        DispatcherTimer imageUpdate;
        string lastImg;
        public PonyPage()
        {
            this.InitializeComponent();
            Loaded += PonyPage_Loaded;
        }

        private void PonyPage_Loaded(object sender, RoutedEventArgs e)
        {
            NFCMeeting.OnPonyMet += NFCMeeting_OnPonyMet;
            NFCMeeting.GetReadyToMeetPony();

            imageUpdate = new DispatcherTimer();
            imageUpdate.Interval = new TimeSpan(0, 0, 1);
            imageUpdate.Tick += T_Tick;
            imageUpdate.Start();
        }

        private void NFCMeeting_OnPonyMet()
        {
            new PonyStats().Play();
        }

        private void T_Tick(object sender, object e)
        {
            ShowPonyImage();
        }

        public void ShowPonyImage()
        {
            //Try to get the stats of the pony
            PonyStats pStats = new PonyStats();

            try
            {
                var mood = pStats.GetMood();
                var name = pStats.GetPonyName();
                var url = "ms-appx:///Images/" + name + "/" + mood + ".png";
                if (url != lastImg)
                    PonyImage.Source = new BitmapImage(new Uri(url));

                lastImg = url;
            }
            catch (DeadPonyException ex)
            {
                //If the pony is actually dead we get here

                //First we stop the image to update
                imageUpdate.Stop();
                var url = "ms-appx://Images/" + pStats.GetPonyName() + "/sad.png";
                PonyImage.Source = new BitmapImage(new Uri(url));
                DeathGrid.Visibility = Visibility.Visible;
                DeathAnimation.Begin();
                NewPonyButton.Click += NewPonyButton_Click;
            }
        }

        private void NewPonyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChoosePony));
        }

        private async void PonyImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            count++;
            if (count > 7)
            {
                Poop.Visibility = Windows.UI.Xaml.Visibility.Visible;
                await Task.Delay(5000);
                Poop.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                count = 0;
            }

        }

        private async void Share()
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("fb:post?text=My pony is " + new PonyStats().GetAge().Days.ToString() + " days old." + " Try and beat me if you can."));
        }

        private void Shared_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Share();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(
                new Uri(
                    "mailto:moodbeam@outlook.com?subject=Feedback&body=Give feedback"
                    ));
        }
    }
}
