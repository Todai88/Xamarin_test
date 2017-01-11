using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using System.Net.Http;

namespace App3
{
    public partial class DeleteFoundation : ContentPage
    {
        public DeleteFoundation()
        { 
            InitializeComponent();
            lblID.FontAttributes = FontAttributes.Bold;
            lblID.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            lblMapID.FontAttributes = FontAttributes.Bold;
            lblMapID.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            btnDelete.Clicked += async (s, e) =>
            {
                int send_id = int.Parse(txtDeleteFoundation_ID.Text);
                int send_mapid = int.Parse(txtDeleteFoundation_MapID.Text);
                var response = await PostDeleteFoundation(send_id, send_mapid);
                await DisplayAlert("Clicked", "I was clicked. HttpResponse:\n " + response, "OK");
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayAlert("Danger zone", "You are entering the danger zone. Be fucking careful here.\nLive data ahead.", "OK");
        }

        public async Task<string> PostDeleteFoundation(int id, int map_id)
        {

            Debug.WriteLine("I'm in!");
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var content = new StringContent(id.ToString());
            var response = await client.PostAsync(String.Format("http://api.worksiteclouddev.com/RestfulAPI/api/Ole_foundations/Delete/?id={0}&mapId={1}", id, map_id), content); 
            var result = response.Content.ReadAsStringAsync().Result; 
            return result;

        }

    }


}
