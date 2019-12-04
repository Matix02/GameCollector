using GameCollector.Model;
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
    public partial class AvatarPage : ContentPage
    {
        public IList<Avatar> Avatars = new List<Avatar>();
        public AvatarPage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ApiServices apiServices = new ApiServices();
            var imgAvatars = await apiServices.GetAvatar();
            
            foreach (var avatar in imgAvatars)
            {
                    Avatars.Add(avatar);
            }
            avatarLv.ItemsSource = Avatars;
        }

        private async void avatarLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAv = avatarLv.SelectedItem as Avatar;

            User userAv = new User()
            {
                Avatar = selectedAv.Img
            };

            ApiServices apiServices = new ApiServices();
            bool response = await apiServices.EditAvatar(App.myId, userAv);

            if (response != true)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
            else
            {
                await DisplayAlert("Hi", "Your avatar has been changed successfully", "Alright");
            }
        }
    }
}