using GameCollector.Logic;
using GameCollector.Model;
using GameCollector.Services;
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
              ApiServices apiServices = new ApiServices();
              var games = await apiServices.InfoGame(nameGame);
             
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
            ApiServices apiServices = new ApiServices();
            foreach (var submenu in selectedGame.UserDlcs)
            {
                bool responseDlc = await apiServices.DeleteDlc(submenu.ID);
            }
            bool responseGame = await apiServices.DeleteGame(selectedGame.ID);
            
            if (!responseGame == true)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
            else
            {
                await DisplayAlert("Hi", "Your game has been added successfully", "Alright");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var selectedTitle = selectedGame as UserGame;
            Navigation.PushAsync(new RatePage(selectedGame));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var selectedTitle = selectedGame.UserDlcs as UserDlc;
            Navigation.PushAsync(new RateDlcPage(selectedGame));
        }
    }
}