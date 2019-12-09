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
    public partial class SearchPage : ContentPage
    {
        public ObservableCollection<Game> MyGames;
        public UserDlc Bufor;
        public List<String> titles;
        public List<String> busyTitles;

        public static bool First = true;
        public SearchPage()
        {
            InitializeComponent();
            MyGames = new ObservableCollection<Game>();
            Bufor = new UserDlc();
            titles = new List<String>();
            busyTitles = new List<String>();
            InitSearchBar();

        }
        void InitSearchBar()
        {
            string checkEmpty = mainSearchBar.Text;
            if(string.IsNullOrEmpty(checkEmpty))
            {
                mainSearchBar.TextChanged += (s, e) => FilterItem(mainSearchBar.Text);
                mainSearchBar.SearchButtonPressed += (s, e) => FilterItem(mainSearchBar.Text);
            }
        }
        private async void FilterItem(string filter)
        {
           // MyGames.Clear();
            gameListView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter) || string.IsNullOrEmpty(filter))
            {
////////////////// Jak jest empty lub null występują ostatnie wyszukiwane pozycje, i niekoniecznie potrzeba to "naprawiać"
                MyGames.Clear();
            }
            else
            {
                var games = await Game.SearchGame(titles, busyTitles, filter);
                gameListView.ItemsSource = games;
                MyGames.Clear();
                titles.Clear();
            }
            gameListView.EndRefresh();      
        }
        protected async override void OnAppearing()
        {   
            base.OnAppearing();
            var games = await UserGame.GetMyGame();
            foreach(var game in games)
            {
                if(game.User_ID == App.myId)
                {
                    busyTitles.Add(game.UserTitle);
                }    
            }
        }
        private void GameListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = (ListView)sender;
            list.SelectedItem = null;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            int id;
            string chosenList;
            try
            {
                var button = (Button)sender;
                var classID = button.ClassId;
                var list = (Game)((Button)sender).BindingContext;
                var selectedGame = list;

                if (classID.Equals("History"))
                    chosenList = "History";
                else if (classID.Equals("Future"))
                    chosenList = "Future";
                else
                    chosenList = "Current";

                UserGame userGame = new UserGame()
                {
                    UserTitle = selectedGame.Title,
                Img = selectedGame.Img,
                BackgroundImg = selectedGame.BackgroundImg,
                Rate = 5,
                User_ID = App.myId,
                List = chosenList
            };

                
                await UserGame.AddGame(userGame);
                var games = await UserGame.GetMyGame();
                id = games.LastOrDefault().ID;
                foreach (var dlc in selectedGame.Dlcs)
                {
                    UserDlc dodatki = new UserDlc()
                    {
                        DlcTitle = dlc.DlcTitle,
                        Img = dlc.Img,
                        Rate = 5,
                        Game_ID = id
                    };
                    Bufor = dodatki;
                    await UserDlc.AddDlc(Bufor);
                }
                await DisplayAlert("Hi", "Your game has been added successfully", "Alright");
            }
            catch(NullReferenceException)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
            catch(Exception)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
        }
    }
}