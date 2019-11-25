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
        public ObservableCollection<Game> Bufor;
        public List<String> titles;

        public static bool First = true;
        public SearchPage()
        {
            InitializeComponent();
            MyGames = new ObservableCollection<Game>();
            Bufor = new ObservableCollection<Game>();
            titles = new List<String>();
            InitSearchBar();

        }
        void InitSearchBar()
        {
            string checkEmpty = mainSearchBar.Text;
            if (string.IsNullOrEmpty(checkEmpty))
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
                    if (!titles.Contains(game.Title)){
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
        
        //NoItemSelected
        private void gameListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = (ListView)sender;
            list.SelectedItem = null;
        }

        private async void HistoryButton_Clicked(object sender, EventArgs e)
        {
            var list = (Game)((Button)sender).BindingContext;

            var selectedGame = list;
          /*  UserGame userGame = new UserGame()
            {
                UserTitle = selectedGame.Title,
                Img = selectedGame.Img,
                BackgroundImg = selectedGame.BackgroundImg,
                Rate = 5,
                User_ID = "1",
                List = "Current"
            };*/
            UserGame userGame = new UserGame()
            {
                UserTitle = "Overwatch",
                Img = "https://image.ceneostatic.pl/data/products/47973537/i-overwatch-origins-edition-digital.jpg",
                BackgroundImg = "https://wallpaperplay.com/walls/full/1/1/3/223487.jpg",
                Rate = 4,
                User_ID = "1",
                List = "Current"
            };
            ApiServices apiServices = new ApiServices();
            bool response = await apiServices.AddGame(userGame);
            if(response != true)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
            else
            {
                await DisplayAlert("Hi", "Your table has been reserved successfully", "Alright");
            }
        }

        private void NowButton_Clicked_1(object sender, EventArgs e)
        {

        }

        private void FutureButton_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}