using GameCollector.Model;
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
            lPlayed.Text = "0";
            lPlaying.Text = "0";
            lToPlay.Text = "0";
        }
        /*Po schowaniu aplikacji i powróceniu do niej będąc na ProfilePage'u ponownie ładuje się OnAppearing, 
         * który dubluje dane z ilosci przechowywanych gier*/
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var avatars = await User.GetUser(App.myId);
            int played = 0;
            int playing = 0;
            int want = 0;
            foreach (var user in avatars)
            {
                avatarIb.Source = user.Avatar;
            }

            var imgAvatars = await UserGame.GetMyGame();
            if (imgAvatars.Count == 0)
            {
                lPlayed.Text = "0";
                lPlaying.Text = "0";
                lToPlay.Text = "0";
            }
            else
            {
                foreach (var game in imgAvatars)
                {
                    if (game.User_ID == App.myId)
                    {
                        if (game.List.Trim() == "Current")
                        {
                            playing++;
                            lPlaying.Text = playing.ToString();
                        }
                        else if(game.List.Trim() == "Future")
                        {
                            played++;
                            lPlayed.Text = played.ToString();
                        }
                        else if(game.List.Trim() == "History")
                        {
                            want++;
                            lToPlay.Text = want.ToString();
                        }
                    }
                }
            }
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AvatarPage());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}