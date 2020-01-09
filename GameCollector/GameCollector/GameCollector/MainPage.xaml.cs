using GameCollector.Model;
using GameCollector.ViewModel;
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
        HomeVM viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new HomeVM();
            BindingContext = viewModel;

        }
        /*Dodać funkcję logowania offline, jeśli nie ma internetu przeskakuje na konto, 
        które było ostatnio zalogowane*/

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            busyIndicator.IsRunning = true;
            bool canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);
            if (canLogin)
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                busyIndicator.IsRunning = false;
                await DisplayAlert("Error", "Something goes wrong. Try again", "Ok");
                
            }
        }
    }
}
