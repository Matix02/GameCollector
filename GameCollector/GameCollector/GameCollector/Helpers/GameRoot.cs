using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollector.Helpers
{

    public class Dlc
    {
        public int ID { get; set; }
        public string DlcTitle { get; set; }
        public string Img { get; set; }
        public int Game_ID { get; set; }
    }

    public class Developer
    {
        public IList<object> Games { get; set; }
        public int ID { get; set; }
        public string DeveloperName { get; set; }
    }

    public class Game
    {
        public Developer Developer { get; set; }
        public IList<Dlc> Dlcs { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime RelaseDate { get; set; }
        public string Img { get; set; }
        public string BackgroundImg { get; set; }
        public int Platform_ID { get; set; }
        public int Developer_ID { get; set; }
    }
    public class Platform
    {
        public IList<Game> Games { get; set; }
        public int ID { get; set; }
        public string PlatformName { get; set; }
    }
    public class GameRoot
    {
        public const string GAME_SEARCH = "https://collectorgameapp.azurewebsites.net/api/Games";
    }
}








