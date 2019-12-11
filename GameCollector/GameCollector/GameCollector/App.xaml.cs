using GameCollector.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameCollector
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static MobileServiceClient MobileService =
            new MobileServiceClient(
                "https://collectorgameapp.azurewebsites.net"
                );
        public static IMobileServiceSyncTable<UserGame> userGameTable;
        public static int myId = 0;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;

            var store = new MobileServiceSQLiteStore(databaseLocation);
            store.DefineTable<UserGame>();

            MobileService.SyncContext.InitializeAsync(store);
            userGameTable = MobileService.GetSyncTable<UserGame>();
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
