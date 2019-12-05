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
    public partial class RatePage : ContentPage
    {
        readonly UserGame userGame;
        public RatePage(UserGame userGame)
        {
            InitializeComponent();
            this.userGame = userGame;
        }

        private async void RateButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var userGameId = userGame.ID;
                var button = (Button)sender;
                int clkNb = System.Convert.ToInt32(button.ClassId);

                UserGame userRate = new UserGame()
                {
                    Rate = clkNb
                };
                await UserGame.EditGameRate(userGameId, userRate);
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