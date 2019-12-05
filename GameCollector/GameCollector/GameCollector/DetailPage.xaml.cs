using GameCollector.Logic;
using GameCollector.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameCollector
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        readonly UserGame selectedGame;
        public ObservableCollection<UserDlc> MyGames;

        public DetailPage(UserGame selectedGame)
        {
            //pozamieniać nazwy tychże list Obser..., jednakowość w tym przypadku not good
            //dodać zabezpiecznie, że jak nie ma internetu to nie wchodzi się do części bazy "Game" poprzez if
            InitializeComponent();
            this.selectedGame = selectedGame;
            imgBtnPlayed.BackgroundColor = Color.White;
         //BindingContext to Controls
            btnMainRate.Text = selectedGame.Rate.ToString();
            imgBG.Source = selectedGame.BackgroundImg;
            imgCover.Source = selectedGame.Img;
            
         //Binding List 
            MyGames = new ObservableCollection<UserDlc>();
            foreach (var submenu in selectedGame.UserDlcs)
            {
                MyGames.Add(submenu);
            }
            LvDlcs.ItemsSource = MyGames;
        }
        protected async override void OnAppearing()
         {
            base.OnAppearing();
            string nameGame = selectedGame.UserTitle;
            string nameList = selectedGame.List;
            var games = await Game.InfoGame(nameGame);

            switch (nameList.Trim()) {
                case "History":
                    imgBtnWant.Source = "wantOffHeist.png";
                    imgBtnPlaying.Source = "playingOffHeist.png";
                    imgBtnPlayed.Source = "playedOnHeist.png";
                    break;
                case "Future":
                    imgBtnWant.Source = "wantOnHeist.png";
                    imgBtnPlaying.Source = "playingOffHeist.png";
                    imgBtnPlayed.Source = "playedOffHeist.png";
                    break;
                case "Current":
                    imgBtnWant.Source = "wantOffHeist.png";
                    imgBtnPlaying.Source = "playingOnHeist.png";
                    imgBtnPlayed.Source = "playedOffHeist.png";
                    break;
            }

             
            foreach(var game in games)
            {
                if (game.Platform.PlatformName.Equals("Pc"))
                    btnPc.IsVisible = true;
                else if (game.Platform.PlatformName.Equals("Xbox One"))
                    btnPs3.IsVisible = true;
                else if (game.Platform.PlatformName.Equals("Ps3"))
                    btnPs3.IsVisible = true;
                else if (game.Platform.PlatformName.Equals("Ps4"))
                    btnPs3.IsVisible = true;

                labDev.Text = game.Developer.DeveloperName.ToString();
                DateTime dateTime = game.RelaseDate;

                labDate.Text = String.Format("{0:dd/MM/yyyy}", dateTime);
            }
        }

        private async void  ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Utworzyć funkcję, do tych pętl, bo powtarzany jest KOD !!!!
            foreach (var submenu in selectedGame.UserDlcs)
            {
                bool responseDlc = await UserDlc.DeleteDlc(submenu.ID);
            }
            bool responseGame = await UserGame.DeleteGame(selectedGame.ID);
            
            if (!responseGame == true)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
            else
            {
                await DisplayAlert("Hi", "Your game has been deleted successfully", "Alright");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var selectedTitle = selectedGame as UserGame;
            Navigation.PushAsync(new RatePage(selectedTitle));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //var selectedTitle = selectedGame.UserDlcs as UserDlc;
            //Navigation.PushAsync(new RateDlcPage(selectedTitle));
        }
    }
}