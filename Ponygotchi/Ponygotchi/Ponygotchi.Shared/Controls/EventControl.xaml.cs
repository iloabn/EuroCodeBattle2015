using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Ponygotchi.Controls
{
    public sealed partial class EventControl : UserControl
    {
        public EventControl()
        {
            this.InitializeComponent();
            Loaded += EventControl_Loaded;
            Tapped += EventControl_Tapped;
        }

        private void EventControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var pStats = new GameLogic.PonyStats();
            switch (this.Name)
            {
                case "Food":
                    pStats.Eat();
                    break;
                case "Play":
                    pStats.Play();
                    break;
                case "Sleep":
                    pStats.Sleep();
                    break;
            }
        }

        private void EventControl_Loaded(object sender, RoutedEventArgs e)
        {
            var pStats = new GameLogic.PonyStats();
            string uri = "ms-appx:///Images/Needs/";
            switch (this.Name)
            {
                case "Food":
                    uri += "Apple";
                    eventBar.Value = 100 - pStats.GetHunger();
                    break;
                case "Play":
                    uri += "Ball";
                    eventBar.Value = 100 - pStats.GetBoredom();
                    break;
                case "Sleep":
                    uri += "Sleep";
                    eventBar.Value = 100 - pStats.GetTiredness();
                    break;
            }
            uri += ".png";

            SetColor(eventBar.Value);

            eventImage.Source = new BitmapImage(new Uri(uri));

            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 1);
            t.Tick += T_Tick;
            t.Start();
        }

        private void SetColor(double value)
        {

            if (value < 50)
            {
                eventBar.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (value < 75.5)
                    eventBar.Foreground = new SolidColorBrush(Colors.Orange);
                else
                    eventBar.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        private void T_Tick(object sender, object e)
        {
            SetPercentage();
        }

        private void SetPercentage()
        {
            var pStats = new GameLogic.PonyStats();
            switch (this.Name)
            {
                case "Food":
                    eventBar.Value = 100 - pStats.GetHunger();
                    break;
                case "Play":
                    eventBar.Value = 100 - pStats.GetBoredom();
                    break;
                case "Sleep":
                    eventBar.Value = 100 - pStats.GetTiredness();
                    break;
            }
            SetColor(eventBar.Value);
        }
    }
}
