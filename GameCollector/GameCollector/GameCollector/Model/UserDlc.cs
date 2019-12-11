using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Model
{
    public class UserDlc 
    {
        public int ID { get; set; }
        public string DlcTitle { get; set; }
        public string Img { get; set; }
        public int Rate { get; set; }
        public int Game_ID { get; set; }

        //Stworzenie wyszukiwacza do WebApi, gdzie wpisujemy id gry i na wylistuje specjalnie dlc do niego
        //Powód: szybkość zmiany oceny danego DLC 
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
                    "https://collectorgameapp.azurewebsites.net/RateDlc/", id), content);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
