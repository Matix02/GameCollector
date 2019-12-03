using GameCollector.Model;
using GameCollector.Services;
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
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            
            if (isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                ApiServices apiServices = new ApiServices();
                var games = await apiServices.GetEveryone();
                foreach (var game in games)
                {
                    if(game.Email == emailEntry.Text)
                    {
                        if(game.Password == passwordEntry.Text)
                        {
                            App.myId = game.ID;
                            await Navigation.PushAsync(new HomePage());
                            break;
                        }
                        else
                        {
                            await DisplayAlert("Error", "Email or password are incorrect", "Ok");
                            break;
                        }
                    }
                }
            }
        }

        private void registerLoginButton_Clicked(object sender, EventArgs e)
        {
            

            Navigation.PushAsync(new RegisterPage());
        }
    }
}
