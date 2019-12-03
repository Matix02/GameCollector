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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiServices apiServices = new ApiServices();
            var avatars = await apiServices.GetUser("1");
            foreach(var user in avatars)
            {
                avatarIb.Source = user.Avatar;
            }

            var imgAvatars = await apiServices.GetMyGame();
            if(imgAvatars.Count == 0)
            {
                lPlayed.Text = "0";
                lPlaying.Text = "0";
                lToPlay.Text = "0";
            }
            else
            {
                foreach (var game in imgAvatars)
                {
                    if (game.User_ID == 1)
                    {//Zapewnić informacje jaki User teraz używa aplikacji,
                     //pamiętać o tym przy robieniu logowania/rejestracji
                        if (game.List.Trim() == "Current")
                         lPlaying.Text = imgAvatars.Count.ToString();
                        else if(game.List.Trim() == "History")
                         lPlayed.Text = imgAvatars.Count.ToString();
                        else if(game.List.Trim() == "History")
                         lToPlay.Text = imgAvatars.Count.ToString();
                    }
                }
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AvatarPage());
        }
    }
}