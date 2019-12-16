using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EticaGame.ViewModels
{
   /* public class TurnCommandClass : ICommand
    {
        public GameViewModel ViewModel { get; set; }

        public TurnCommandClass(GameViewModel vm)
        {
            this.ViewModel = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object param)
        {
            if(param != null)
            {
                var ans = param as String;
                ans = ans.Trim();
                if(!string.IsNullOrEmpty(ans))
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object param)
        {
            this.ViewModel.CheckAndGo(param as String);
        }
    }
    */
}
