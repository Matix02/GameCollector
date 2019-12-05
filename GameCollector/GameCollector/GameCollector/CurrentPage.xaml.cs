using GameCollector.Logic;
using GameCollector.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameCollector
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentPage : ContentPage
    {
        // public ObservableCollection<UserGame> MyGames;
        //Zmiana w przypadku Observable na IList, i miejsca inicjalizacji, w ten sposób nie powiela się, ale czy to dobrze?!
        public IList<UserGame> MyGames = new List<UserGame>();
        int check = 0;
        UserGame selectedGame;
        public CurrentPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var games = await UserGame.GetMyGame();
            foreach (var game in games)
            {
                if (game.User_ID == App.myId && game.List.Trim() == "Current")
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
                myGameLv.SelectedItem = null;
            }
            else
            {
                await Navigation.PushAsync(new DetailPage(selectedGame));
                check = 0;
            }
        }
    }
}