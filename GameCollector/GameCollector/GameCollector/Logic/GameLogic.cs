using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCollector.Logic
{
    public class GameLogic
    {
        public static async Task<List<Game>> GetGames()
        {
            List<Game> games = new List<Game>();

            var url = Game.GenerateURL();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var gameRoot = JsonConvert.DeserializeObject<List<Game>>(json);

                games = gameRoot as List<Game>;
            }
            //brakuje przypisania z json'a do games, zwraca pustą listę!!!
            return games;
        }
    }
}
