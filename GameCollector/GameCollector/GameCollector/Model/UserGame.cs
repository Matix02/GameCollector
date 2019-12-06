using GameCollector.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Model
{
    public class UserGame
    {
        public User User { get; set; }
        public IList<UserDlc> UserDlcs { get; set; }
        public int ID { get; set; }
        public string UserTitle { get; set; }
        public int Rate { get; set; }
        public string Img { get; set; }
        public string BackgroundImg { get; set; }
        public int User_ID { get; set; } 
        public string List { get; set; }

        public static async Task<List<UserGame>> GetMyGame()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Users");
                return JsonConvert.DeserializeObject<List<UserGame>>(response);
            }
        }
        public static async Task<IEnumerable<UserGame>> GetMyGameFromList(string list)
        {
            using (HttpClient client = new HttpClient())
            {
                ObservableCollection<UserGame> MyGames = new ObservableCollection<UserGame>();
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Users");
                var games = JsonConvert.DeserializeObject<List<UserGame>>(response);
                foreach (var game in games)
                {
                    if (game.User_ID == App.myId && game.List.Trim() == list)
                        MyGames.Add(game);
                }
                return MyGames;
            }
        }
        public static async Task<bool> AddGame(UserGame userGame)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userGame);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://collectorgameapp.azurewebsites.net/api/Users", content);
                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> DeleteGame(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(
                    String.Concat("https://collectorgameapp.azurewebsites.net/api/Users/", id.ToString()));
                return result.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> EditGameRate(int id, UserGame userGame)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userGame);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Concat(
                    "https://collectorgameapp.azurewebsites.net/RateGame/", id), content);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
