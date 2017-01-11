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
    public partial class CreateFoundation : ContentPage
    {
        public CreateFoundation()
        {
            InitializeComponent();
            lblInstructions.FontAttributes = FontAttributes.Bold;
            lblInstructions.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            btnCreate.Clicked += async (s, e) =>
                {
                    var code = txtCreateFoundation.Text;
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

            var response = await client.PostAsync(String.Format("http://api.worksiteclouddev.com/RestfulAPI/api/Ole_foundations/Insert/?s={0}", arbitrary), content);
            await DisplayAlert("OUTPUT", response.ToString(), "OK");
            var result = response.Content.ReadAsStringAsync().Result;
            await DisplayAlert("OUTPUT", result.ToString(), "OK");
            return result;

        }

    }
}
