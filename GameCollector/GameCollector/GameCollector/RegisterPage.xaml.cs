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
    public partial class RegisterPage : ContentPage
    {
        User user;
        public RegisterPage()
        {
            InitializeComponent();
            user = new User();
            containerStackLayout.BindingContext = user;

        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {

                bool response = await User.RegisterUser(user);

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