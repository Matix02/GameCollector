using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Model
{
    public class User
    {
        public IList<object> UserGames { get; set; }
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Avatar { get; set; }

        public static async Task<List<User>> GetUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://collectorgameapp.azurewebsites.net/api/Users";
                string userId = id.ToString();
                string fullUrl = Path.Combine(apiUrl, userId);
                var response = await client.GetStringAsync(fullUrl);

                return JsonConvert.DeserializeObject<List<User>>(response);
            }
        }
        public static async Task<List<User>> GetEveryone()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/AllUsers");
                return JsonConvert.DeserializeObject<List<User>>(response);
            }
        }
        public static async Task<List<User>> LoginUser()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Users");
                return JsonConvert.DeserializeObject<List<User>>(response);
            }
        }
        public static async Task<bool> RegisterUser(User user)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://collectorgameapp.azurewebsites.net/Register", content);
                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;            
            }
            else
            {
                var games = await User.GetEveryone();
                foreach (var game in games)
                {
                    if (game.Email == email)
                    {
                        if (game.Password == password)
                        {
                            App.myId = game.ID;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
        }
    }
}
