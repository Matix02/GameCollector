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
    public partial class RateDlcPage : ContentPage
    {
        readonly UserGame userGame;
        public RateDlcPage(UserGame userGame)
        {
            InitializeComponent();
            this.userGame = userGame;
        }
/////////////////Korekta wyjdzie, gdy uda się zaimplementować MVVM pattern
        private void RateButton_Clicked(object sender, EventArgs e)
        {
        /*    var userGameId = userGame.UserDlcs;
            
            foreach(var co in userGameId)
            {
               
            }
            var button = (Button)sender;
            int clkNb = System.Convert.ToInt32(button.ClassId);

            UserGame userRate = new UserGame()
            {
                Rate = clkNb
            };

            ApiServices apiServices = new ApiServices();*/
          //  bool response = await apiServices.EditGameRate(userGameId, userRate);
        }
    }
}