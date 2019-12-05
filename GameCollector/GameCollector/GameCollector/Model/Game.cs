using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Logic
{
    public class Game 
    {
        public Developer Developer { get; set; }
        public IList<Dodatki> Dlcs { get; set; }
        public Platform Platform { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime RelaseDate { get; set; }
        public string Img { get; set; }
        public string BackgroundImg { get; set; }
        public int Platform_ID { get; set; }
        public int Developer_ID { get; set; }

      /*  public static async Task<List<Game>> SearchGame()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Games");
                return JsonConvert.DeserializeObject<List<Game>>(response);
            }
        }*/
        public static async Task<List<Game>> InfoGame(string name)
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
        public static async Task<IEnumerable<Game>> SearchGame(List<String> titles, List<String> busyTitles, string filter)
        {
            ObservableCollection<Game> MyGames = new ObservableCollection<Game>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://collectorgameapp.azurewebsites.net/api/Games");
                var games = JsonConvert.DeserializeObject<List<Game>>(response);

            foreach (var game in games)
            {
                if (!titles.Contains(game.Title) && !busyTitles.Contains(game.Title))
                {
                    titles.Add(game.Title);
                    MyGames.Add(game);
                }
            }
                var titlesToShow = MyGames.Where(x => x.Title.ToLower().Contains(filter.ToLower())).Distinct();
                return titlesToShow;
            }
        }
    }
    public class Developer
    {
        public IList<object> Games { get; set; }
        public int ID { get; set; }
        public string DeveloperName { get; set; }
    }

    public class Platform
    {
        public IList<object> Games { get; set; }
        public int ID { get; set; }
        public string PlatformName { get; set; }
    }
    public class Dodatki
    {
        public int ID { get; set; }
        public string DlcTitle { get; set; }
        public string Img { get; set; }
        public int Game_ID { get; set; }
    }

}
