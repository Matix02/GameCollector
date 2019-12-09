using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Model
{
    public class UserDlc : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string DlcTitle { get; set; }
        public string Img { get; set; }
        public int Rate { get; set; }
        public int Game_ID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async Task<bool> AddDlc(UserDlc userDlcs)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userDlcs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://collectorgameapp.azurewebsites.net/api/dlc", content);
                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> DeleteDlc(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(
                    String.Concat("https://collectorgameapp.azurewebsites.net/api/dlc/", id.ToString()));
                return result.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> EditDlcRate(int id, UserDlc userDlc)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userDlc);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Concat(
                    "https://collectorgameapp.azurewebsites.net/api/RateDlc/", id), content);
                return response.IsSuccessStatusCode;
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
