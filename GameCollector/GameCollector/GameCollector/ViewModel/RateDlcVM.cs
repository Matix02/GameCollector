using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace GameCollector.Model
{
    class RateDlcVM : INotifyPropertyChanged
    {
        public Command<object> DeleteCommand { get; set; }
        public RateDlcVM()
        {
            DeleteCommand = new Command<object>(OnTapped);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void OnTapped(object obj)
        {
            var contacts = obj as UserDlc;
            await App.Current.MainPage.Navigation.PushAsync(new RateDlcPage(contacts));
        }
    }
}
