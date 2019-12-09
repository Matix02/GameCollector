using GameCollector.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GameCollector.ViewModel.Commands
{
    public class ChangeListCommand : ICommand
    {
        public DetailVM ViewModel { get; set; }

        public ChangeListCommand(DetailVM detailVM)
        {
            ViewModel = detailVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var who = (UserGame)parameter;
            return false;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
