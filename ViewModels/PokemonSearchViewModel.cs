using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mvvmdex.Models;

namespace Mvvmdex.ViewModels
{
    public class PokemonSearchViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseOnPropertyChange([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private MvvmdexClient _client;

        public PokemonSearchViewModel()
        {
            _client = new MvvmdexClient();
        }

        private string _pokemonName;

        public string PokemonName
        {
            get { return _pokemonName; }
            set { _pokemonName = value; RaiseOnPropertyChange(); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set{ _description = value; RaiseOnPropertyChange(); }
        }

		public string SearchTerms { get; set; }

        private string _shape;

        public string Shape
        {
            get { return _shape; }
            set { _shape = value; RaiseOnPropertyChange(); }
        }

        private bool _hasCoincidence;

        public bool HasCoincidence
        {
            get { return _hasCoincidence; }
            set { _hasCoincidence = value; RaiseOnPropertyChange(); }
        }

        private ICommand _buscaPokemonCommand;
        public ICommand BuscaPokemonCommand
        {
            get
            {
                if (_buscaPokemonCommand == null)
                {
					Action buscaPokemonAction = async () =>
					{
					var pokemon = await _client.SearchForPokemon(SearchTerms.ToLower());

                        HasCoincidence = pokemon != null;
                        if (HasCoincidence)
                        {
                            Description = pokemon.Description;
                            PokemonName = String.Format("{0:D3} {1}", pokemon.Id, pokemon.Name);
                            Shape = pokemon.Shape;
                        }
                    };
                    _buscaPokemonCommand = new BuscaPokemonCommand(buscaPokemonAction);
                }
                return _buscaPokemonCommand;
            }
        }
    }
}

