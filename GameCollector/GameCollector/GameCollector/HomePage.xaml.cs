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
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            //zeby zwracało jako User co kliknął odnosnić w CurrentPage.xaml 
            Navigation.PushAsync(new ProfilePage());
        }
    }
}