using GameCollector.Model;
using GameCollector.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollector.ViewModel
{
    public class DetailVM
    {
        public UserGame UserGame { get; set; }

        public ChangeListCommand ChangeListCommand { get; set; }

        public DetailVM()
        {
            UserGame = new UserGame();
            ChangeListCommand = new ChangeListCommand(this);
        }
    }
}
