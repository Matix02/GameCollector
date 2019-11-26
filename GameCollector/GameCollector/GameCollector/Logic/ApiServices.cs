using GameCollector.Logic;
using GameCollector.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Services
{
    public class ApiServices
    {
        public async Task<List<UserGame>> GetMyGame()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Users");
                return JsonConvert.DeserializeObject<List<UserGame>>(response);
            }
        }
        public async Task<bool> AddGame(UserGame userGame)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(userGame);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://collectorgameapp.azurewebsites.net/api/Users", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteGame(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var httpClient = new HttpClient();
                var result = await httpClient.DeleteAsync(
                    String.Concat("https://collectorgameapp.azurewebsites.net/api/Users/", id.ToString()));

                return result.IsSuccessStatusCode;
            }
        }
        public async Task<bool> EditAvatar(string id, User user)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(String.Concat(
                "https://collectorgameapp.azurewebsites.net/api/Users/", id),content);
            return response.IsSuccessStatusCode;
        }
        public async Task<List<Game>> SearchGame()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Games");
                return JsonConvert.DeserializeObject<List<Game>>(response);
            }
        }
        public async Task<List<Game>> InfoGame(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://collectorgameapp.azurewebsites.net/games/";
                string nameGame = name;
                string fullUrl = Path.Combine(apiUrl, nameGame);
                var response = await client.GetStringAsync(fullUrl);

                return JsonConvert.DeserializeObject<List<Game>>(response);
            }
        }
        public async Task<List<Avatar>> GetAvatar()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Avatars");
                return JsonConvert.DeserializeObject<List<Avatar>>(response);
            }
        }

    }
}
