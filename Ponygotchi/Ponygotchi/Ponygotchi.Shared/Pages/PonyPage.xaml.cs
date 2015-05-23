﻿using Ponygotchi.GameLogic;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ponygotchi.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PonyPage : Page
    {
        public PonyPage()
        {
            this.InitializeComponent();
        }

        public void ShowPonyImage()
        {
            PonyStats pStats = new PonyStats();
            var mood = pStats.GetMood();
            var name = pStats.GetPonyName();
            var url = "ms-appx:///Images/" + name + "/" + mood + ".png";
            PonyImage.Source = new BitmapImage(new Uri(url));

        }

       

    }
}
