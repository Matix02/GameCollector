using GameCollector.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollector.ViewModel
{
    public class HomeVM
    {
        public NavigationCommand NavCommand { get; set; }

        public HomeVM()
        {
            NavCommand = new NavigationCommand(this);
        }
        public async void Navigate()
        {
           await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
