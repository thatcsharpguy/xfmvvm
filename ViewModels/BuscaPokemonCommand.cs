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
        private readonly Action _search;
        public BuscaPokemonCommand(Action search)
        {
            _search = search;
        }

        public bool CanExecute(object parameter)
        {
			return true;
        }

        public void Execute(object parameter)
        {
                _search();
        }

        public event EventHandler CanExecuteChanged;
    }
}
