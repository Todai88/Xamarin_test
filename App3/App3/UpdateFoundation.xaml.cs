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
    public partial class UpdateFoundation : ContentPage
    {
        public UpdateFoundation()
                {
            InitializeComponent();
            lblInstructions.FontAttributes = FontAttributes.Bold;
            lblInstructions.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            btnUpdate.Clicked += async (s, e) =>
                {
                    var code = txtUpdateFoundation.Text;
                    var arb = await PostCreateFoundation(code); 
                    await DisplayAlert("Clicked", "I was clicked. Text was: " + arb, "OK");
                };
        }


        public async Task<string> PostCreateFoundation(string arbitrary)
        {

            Debug.WriteLine("I'm in!");
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var content = new StringContent(arbitrary); 

            var response = await client.PostAsync(String.Format("http://api.worksiteclouddev.com/RestfulAPI/api/Ole_foundations/Update/?s={0}", arbitrary), content); 
            var result = response.Content.ReadAsStringAsync().Result; 
            return result;

        }

    } 
}
