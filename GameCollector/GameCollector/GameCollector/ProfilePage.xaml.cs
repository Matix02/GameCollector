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
            var imgAvatars = await apiServices.GetMyGame();
            foreach (var game in imgAvatars)
            {
                if (game.User_ID == "1")
                {//Zapewnić informacje jaki User teraz używa aplikacji,
                    //pamiętać o tym przy robieniu logowania/rejestracji
                    avatarIb.Source = game.User.Avatar;
                    //lPlayed.Text = imgAvatars.Count;

                }
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AvatarPage());
        }
    }
}