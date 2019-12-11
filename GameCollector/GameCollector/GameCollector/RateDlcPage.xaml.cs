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
    public partial class RateDlcPage : ContentPage
    {
        readonly UserDlc userDlc;
        public RateDlcPage(UserDlc userDlc)
        {
            InitializeComponent();
            this.userDlc = userDlc;

        }
/////////////////Korekta wyjdzie, gdy uda się zaimplementować MVVM pattern
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var userDlcId = userDlc.ID;
                var button = (Button)sender;
                int clkNb = System.Convert.ToInt32(button.ClassId);

                UserDlc userRate = new UserDlc()
                {
                    Rate = clkNb
                };
                await UserDlc.EditDlcRate(userDlcId, userRate);
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