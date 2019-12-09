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
    public partial class AvatarPage : ContentPage
    {
        User user;
        public AvatarPage()
        {
            InitializeComponent();
            user = new User();
            avatarLv.BindingContext = user;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var imgAvatars = await Avatar.GetAvatar();
            avatarLv.ItemsSource = imgAvatars;
        }
        private async void AvatarLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedAv = avatarLv.SelectedItem as Avatar;

                user.Avatar = selectedAv.Img;

                await Avatar.EditAvatar(App.myId, user);
                await DisplayAlert("Hi", "Your avatar has been changed successfully", "Alright");
            }
            catch (NullReferenceException)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");

            }
            catch (Exception)
            {
                await DisplayAlert("Oops", "Something goes wrong", "Alright");
            }
        }
    }
}