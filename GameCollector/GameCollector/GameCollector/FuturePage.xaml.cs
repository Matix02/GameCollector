﻿using GameCollector.Model;

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
       // public IList<UserGame> MyGames = new List<UserGame>();
        int check = 0;
        UserGame selectedGame;
        public FuturePage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            string list = "History";
            var games = await UserGame.GetMyGameFromList(list);
            
            /*  foreach (var game in games)
              {
                  if (game.User_ID == App.myId && game.List.Trim() == "History")
                      MyGames.Add(game);
              }*/

            await myGameLv.FadeTo(0, 500);
            myGameLv.ItemsSource = games;
            await myGameLv.FadeTo(1, 1000);
            
            

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