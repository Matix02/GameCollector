using System;
using System.Collections.Generic;
using System.Text;

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
        public string User_ID { get; set; }
        public string List { get; set; }
    }
    public class User
    {
        public IList<object> UserGames { get; set; }
        public string ID { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Avatar { get; set; }
    }

    public class UserDlc
    {
        public int ID { get; set; }
        public string DlcTitle { get; set; }
        public string Img { get; set; }
        public int Rate { get; set; }
        public int Game_ID { get; set; }
    }
}
