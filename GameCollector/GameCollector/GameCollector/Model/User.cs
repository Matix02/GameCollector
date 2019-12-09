using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Model
{
    public class User : INotifyPropertyChanged
    {
        //Zostawić to na później, zająć się zmianami listy i ikonkami - spróbować zrobić OnPropertyChanged na buttonach
        public IList<object> UserGames { get; set; }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string type;

        public string Type
        {
            get {
                if (type == null)
                    return "user";
                else
                    return type; }
            set { type = value; }
        }

        private string avatar;

        public string Avatar
        {
            get { return avatar; }
            set { avatar = value;
               // OnPropertyChanged(nameof(Avatar));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

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

        private void OnPropertyChanged(string propertyName)
        {
            if(propertyName != null )
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }   
}
