using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvmdex.ViewModels
{
    public class BuscaPokemonCommand : ICommand
    {
        private readonly Action<string> _search;
        public BuscaPokemonCommand(Action<string> search)
        {
            _search = search;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                var pokemon = (string) parameter;
                return !String.IsNullOrEmpty(pokemon);
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _search(parameter as string);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
