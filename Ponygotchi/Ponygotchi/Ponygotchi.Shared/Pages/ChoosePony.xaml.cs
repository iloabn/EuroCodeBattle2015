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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ponygotchi.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChoosePony : Page
    {
        public ChoosePony()
        {
            this.InitializeComponent();

            SelecteOne.Text = "Select your pony:";
        }

        public void SelectedPony(object sender, RoutedEventArgs e)
        {
            PonyStats ponyStats = new PonyStats();
            var myPony = (sender as Button).Name;
            ponyStats.ResetPony(myPony);
            this.Frame.Navigate(typeof(PonyPage));
        }
    }
}
