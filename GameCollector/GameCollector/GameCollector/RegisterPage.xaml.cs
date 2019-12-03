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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                ApiServices apiServices = new ApiServices();
                User user = new User()
                {
                    //Zmienić z bazy danych String na Int przy ID User
                    Nickname = nickEntry.Text,
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text,
                    Type = "user"
                };
                bool response = await apiServices.RegisterUser(user);

                if(response)
                    await DisplayAlert("Hi", "Your game has been added successfully", "Alright");
                else
                    await DisplayAlert("Error", "Something goes wrong", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}