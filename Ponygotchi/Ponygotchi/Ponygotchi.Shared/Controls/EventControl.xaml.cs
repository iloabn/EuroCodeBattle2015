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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Ponygotchi.Controls
{
    public sealed partial class EventControl : UserControl
    {
        public EventControl()
        {
            this.InitializeComponent();
            Loaded += EventControl_Loaded;
        }

        private void EventControl_Loaded(object sender, RoutedEventArgs e)
        {
            string uri = "ms-appx:///Images/Icon/";
            switch(this.Name)
            {
                case "Food":
                    uri += "Apple";
                    break;
                case "Play":
                    uri += "Ball";
                    break;
                case "Sleep":
                    uri += "Sleep";
                    break;
            }
            uri += ".png";
            eventImage.Source = new BitmapImage(new Uri(uri));
        }
    }
}
