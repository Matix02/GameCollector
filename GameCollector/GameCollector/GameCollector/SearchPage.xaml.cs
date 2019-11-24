using GameCollector.Logic;
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
        public static bool First = true;
        public SearchPage()
        {
            InitializeComponent();
            MyGames = new ObservableCollection<Game>();
            InitSearchBar();
        }
        void InitSearchBar()
        {
            
            mainSearchBar.TextChanged += (s, e) => FilterItem(mainSearchBar.Text);
            mainSearchBar.SearchButtonPressed += (s, e) => FilterItem(mainSearchBar.Text);
        }
        private async void FilterItem(string filter)
        {
            MyGames.Clear();
            gameListView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter))
            {
                ApiServices apiServices = new ApiServices();
                var games = await apiServices.SearchGame();

                //dwie mozliwosci, 1.Dwa obesrcoll.. jedno jest porównywane z drugą jak znajdzie to samo to out
                //2.Wykorzystujemy indexof i następnie removeat i jedziemy dalej
                //3, albo zczytywanie tytułów w pętli do tablicy stringów i czy taki wystąpił, jak tak to out
                foreach (var game in games)
                {
                    MyGames.IndexOf(game);
                    MyGames.Add(game);
                }
                gameListView.ItemsSource = MyGames.Distinct();
            }
            else
            {
                ApiServices apiServices = new ApiServices();
                var games = await apiServices.SearchGame();

                foreach (var game in games)
                {
                    if(!game.Title.Equals(game.Title))
                        MyGames.Add(game);
                }
                gameListView.ItemsSource = MyGames.Where(x => x.Title.ToLower().Contains(filter.ToLower())).Distinct();
            }
            gameListView.EndRefresh();      
        }
    }
}
        /*  private async void  FilterItem(string filter)
          {
              gameListView.BeginRefresh();
              if (string.IsNullOrWhiteSpace(filter))
              {
                  ApiServices apiServices = new ApiServices();
                  var games = await apiServices.SearchGame();

                      foreach (var game in games)
                      {
                              MyGames.Add(game);
                      }
                      gameListView.ItemsSource = MyGames;
              }
              else
              {
                  ApiServices apiServices = new ApiServices();
                  var games = await apiServices.SearchGame();

                  foreach (var game in games)
                  {
                      MyGames.Add(game);
                  }
                  gameListView.ItemsSource = MyGames;*/
        //gameListView.ItemsSource = MyGames

        /*
        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        {
            conn.CreateTable<Game>();
            var games = conn.Table<Game>().ToList();
            gameListView.ItemsSource = games.Where(x => x.Title.ToLower().Contains(filter.ToLower()));
        }
        // gameListView.ItemsSource = Items.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        */
        /*   }
           gameListView.EndRefresh();
       }*/

        /*   private async void MainSearchBar_TextChangedAsync(object sender, TextChangedEventArgs e)
           {
               var keyword = mainSearchBar.Text;
               ApiServices apiServices = new ApiServices();
               var games = await apiServices.SearchGame();

               foreach (var game in games)
               {
                   MyGames.Add(game);
               }

               if (keyword.Length >= 1)
                   {
                       var suggestion = MyGames.Where(c => c.Title.ToLower().Contains(keyword.ToLower()));
                       gameListView.ItemsSource = suggestion;
                       gameListView.IsVisible = true;
                   }
                   else
                   {
                      gameListView.IsVisible = false;
                   }

           }*/
