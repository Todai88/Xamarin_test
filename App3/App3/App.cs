using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public class App : Application
    {
        static FoundationsDatabase db;

        public App()
        {
            //MainPage = new NavigationPage(new Page1Xaml());

            MainPage = new NavigationPage(new FirstPage());
        }

        public static FoundationsDatabase Database
        {
            get
            {
                if (db == null)
                {
                    db = new FoundationsDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Test.db3"));
                }
                return db;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
