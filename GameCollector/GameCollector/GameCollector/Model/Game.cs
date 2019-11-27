using System;
using System.Collections.Generic;
using System.Text;

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
