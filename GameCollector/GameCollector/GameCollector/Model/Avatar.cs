using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Model
{
    public class Avatar : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string AvatarName { get; set; }
        public string Img { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async Task<bool> EditAvatar(int id, User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Concat(
                    "https://collectorgameapp.azurewebsites.net/api/Users/", id), content);
                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<IList<Avatar>> GetAvatar()
        {
            IList<Avatar> Avatars = new List<Avatar>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Avatars");
                var imgAvatars = JsonConvert.DeserializeObject<List<Avatar>>(response);
                foreach (var avatar in imgAvatars)
                {
                    Avatars.Add(avatar);
                }
                return Avatars;
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
