using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;

using Xamarin.Forms;

namespace App3
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent(); 
            lblWelcome.FontAttributes = FontAttributes.Bold;
            lblWelcome.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));

            btnTest.Clicked += async (sender, args) =>
                {
                    lblConnectivity.Text = CrossConnectivity.Current.IsConnected ? "I am connected" : "I am not connected...";
                    lblConnectionType.Text = "Connection Types: ";

                    foreach (var band in CrossConnectivity.Current.ConnectionTypes)
                    {
                        lblConnectionType.Text += band.ToString() + ", ";
                    }
                };

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
                {
                    DisplayAlert("Connectivity changed", "Is Connected: " + args.IsConnected.ToString(), "OK");
                };

        }

        async void OnGetButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetFoundationPage());
        }

        async void OnSetButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SetFoundationPage());
        }

    }
}
