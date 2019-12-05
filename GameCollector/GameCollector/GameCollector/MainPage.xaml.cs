using GameCollector.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameCollector
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //public ObservableCollection<User> MyGames;
        public MainPage()
        {
            InitializeComponent();
        }
        /*Dodać funkcję logowania offline, jeśli nie ma internetu przeskakuje na konto, 
        które było ostatnio zalogowane*/

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);
            if (canLogin)
                await Navigation.PushAsync(new HomePage());
            else
                await DisplayAlert("Error", "Something goes wrong. Try again", "Ok");
        }

        private void RegisterLoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
