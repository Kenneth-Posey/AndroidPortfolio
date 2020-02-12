using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeForChorein.Services;
using TimeForChorein.Views;
using System.IO;
using TimeForChorein.Models;

namespace TimeForChorein
{
    public partial class App : Application
    {
        static DataStore _database;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ChoreService>();

            MainPage = new MainPage();
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

        public static DataStore Database
        {
            get
            {
                if (_database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3");
                    _database = new DataStore(dbPath);
                }
                return _database;
            }
        }
    }
}
