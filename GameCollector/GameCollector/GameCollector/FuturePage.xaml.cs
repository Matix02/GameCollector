using GameCollector.Model;
using GameCollector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameCollector
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuturePage : ContentPage
    {
        // public ObservableCollection<UserGame> MyGames;
        //Zmiana w przypadku Observable na IList, i miejsca inicjalizacji, w ten sposób nie powiela się, ale czy to dobrze?!
        public IList<UserGame> MyGames = new List<UserGame>();
        int check = 0;
        UserGame selectedGame;
        public FuturePage()
        {
            InitializeComponent();
            //  MyGames = new ObservableCollection<UserGame>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiServices apiServices = new ApiServices();
            var games = await apiServices.GetMyGame();
            foreach (var game in games)
            {
                if (game.User_ID == App.myId && game.List.Trim() == "History")
                    MyGames.Add(game);
            }
            myGameLv.ItemsSource = MyGames;
        }

        private async void GameListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (check == 0)
            {
                check = 1;
                selectedGame = myGameLv.SelectedItem as UserGame;
                // var selectedGame = myGameLv.SelectedItem as UserGame;
                myGameLv.SelectedItem = null;

                // await Navigation.PushAsync(new DetailPage(selectedGame));

            }
            else
            {
                // var selectedGame = myGameLv.SelectedItem as UserGame;
                // myGameLv.SelectedItem = null;
                await Navigation.PushAsync(new DetailPage(selectedGame));
                check = 0;
            }
        }
    }
}