using GameCollector.Logic;
using GameCollector.Model;
using GameCollector.Services;
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
        public ObservableCollection<UserGame> Bufor;
        public List<String> titles;
        public List<String> busyTitles;

        public static bool First = true;
        public SearchPage()
        {
            InitializeComponent();
            MyGames = new ObservableCollection<Game>();
            Bufor = new ObservableCollection<UserGame>();
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
                ApiServices apiServices = new ApiServices();
                var games = await apiServices.SearchGame();

                foreach (var game in games)
                {
                    if(!titles.Contains(game.Title) && !busyTitles.Contains(game.Title))
                    {
                        titles.Add(game.Title);
                        MyGames.Add(game);
                    }  
                }
                
                gameListView.ItemsSource = MyGames.Where(x => x.Title.ToLower().Contains(filter.ToLower())).Distinct();
                MyGames.Clear();
                titles.Clear();
            }
            gameListView.EndRefresh();      
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ApiServices apiServices = new ApiServices();
            var games = await apiServices.GetMyGame();
  //////sprawdzić jaka czy jest różnica jeśli chodzi o pręd., gdy WebApi zwraca dane metodą o argumencie ID user
            foreach(var game in games)
            {
                if(game.User_ID == "1")
                {
                    Bufor.Add(game);
                    busyTitles.Add(game.UserTitle);
                }    
            }
        }

        //NoItemSelected
        private void gameListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = (ListView)sender;
            list.SelectedItem = null;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var classID = button.ClassId;
            var list = (Game)((Button)sender).BindingContext;
           
            var selectedGame = list;

            string chosenList;
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
                User_ID = "1",
                List = chosenList
            };
            
            ApiServices apiServices = new ApiServices();
            bool response = await apiServices.AddGame(userGame);
            if(response != true)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
            else
            {
                await DisplayAlert("Hi", "Your game has been added successfully", "Alright");
            }
        }
    }
}