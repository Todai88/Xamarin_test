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

namespace App3
{
    public partial class GetFoundationPage : ContentPage
    {
        public GetFoundationPage()
        {
            InitializeComponent();
            lblResults.IsVisible = false;
            lblResults.FontAttributes = FontAttributes.Bold;
            btnClear.IsVisible = false; 
            btnFoundationFilter.Clicked += async (s, e) =>
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var code = txtFoundationFilter.Text;
                var result = await GetFoundationsAsync(code);
                ListView lv = lvResults;

                lblResults.IsVisible = true;
                lv.ItemsSource = result; 
               // lv.ItemTemplate = new DataTemplate(typeof(TextCell));
               // lv.ItemTemplate.SetBinding(TextCell.TextProperty, "Summary");
                lv.ItemSelected += async (sender, ev) =>
                {
                    var details = (Foundation)ev.SelectedItem;
                    await DisplayAlert("Detailed info:", details.ToString(), "OK");
                };
                if (result.Count == 0)
                {
                    lblResults.Text = "No results...";
                    
                }
                btnClear.IsVisible = true;
                //mainStackLayout.Children.Add(lv);
                //Content = new StackLayout
                //{
                //    Children = {
                //            lv
                //        }
                //};

                watch.Stop();
                var elapsedMS = watch.ElapsedMilliseconds;
                await DisplayAlert("Alert", "It took me : " + elapsedMS.ToString() + "ms to finish! :)", "OK");
            };

            btnAllFoundations.Clicked += async (s, e) =>
                {
                var watch2 = System.Diagnostics.Stopwatch.StartNew();
                var result = await GetAllFoundationsAsync();
                ListView lv = lvResults;

                btnClear.IsVisible = true;
                lv.ItemsSource = result; 
               // lv.ItemTemplate = new DataTemplate(typeof(TextCell));
               // lv.ItemTemplate.SetBinding(TextCell.TextProperty, "Summary");
                int count = 0;
                foreach (Foundation found in result)
                {
                    await App.Database.SaveItemAsync(found);
                    count++;
                    Debug.WriteLine(count.ToString());
                }

                lv.ItemSelected += async (sender, ev) =>
                {
                    var details = (Foundation)ev.SelectedItem;
                    await DisplayAlert("Detailed info:", details.ToString(), "OK");
                };
                lblResults.IsVisible = true;
                //if (!mainStackLayout.Children.Contains(lv))
                //{
                //    mainStackLayout.Children.Add(lv.Id);
                //}
                //else
                //{
                //    mainStackLayout.Children.Remove(lv.Id);
                //    mainStackLayout.Children.Add(lv);
                //}

                //Content = new StackLayout
                //{
                //    Children = {
                //            lv
                //        }
                //};

                watch2.Stop();
                var elapsedSeconds = watch2.Elapsed.Seconds;
                await DisplayAlert("Alert", "It took me : " + elapsedSeconds.ToString() + "s to finish! :)\nThere were " + result.Count + " items", "OK");
            };

            btnClear.Clicked += async (s, e) =>
                {
                    lvResults.ItemsSource = null;
                    btnClear.IsVisible = false;
                    lblResults.IsVisible = false;
                    await DisplayAlert("Alert", "I've cleared the ItemSource", "OK");
                };
                } 

        public async Task<List<Foundation>> GetFoundationsAsync(string code)
        {
            Debug.WriteLine("I'm in!");
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = String.Format("http://api.worksiteclouddev.com/RestfulAPI/api/Ole_foundations/Get/?get_id={0}", code);

            var response = await client.GetAsync(address);

            var foundationJson = response.Content.ReadAsStringAsync().Result; 
            List<Foundation> foundationobject = JsonConvert.DeserializeObject<List<Foundation>>(foundationJson);
            //ObservableCollection<Foundation> list = new ObservableCollection<Foundation>();
            //list.Add(foundationobject);
            return foundationobject;
        }

        public async Task<List<Foundation>> GetAllFoundationsAsync()
        { 

            Debug.WriteLine("I'm in!");
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = String.Format("http://api.worksiteclouddev.com/RestfulAPI/api/Ole_foundations/GetAll");

            var response = await client.GetAsync(address);

            var foundationJson = response.Content.ReadAsStringAsync().Result;
            List<Foundation> foundations = JsonConvert.DeserializeObject<List<Foundation>>(foundationJson);

            //ObservableCollection<Foundation> list = new ObservableCollection<Foundation>();
            //foreach (Foundation foun in foundations){
            //    list.Add(foun);
            //}
            return foundations;
        }
    } 
}
