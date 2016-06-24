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
	}
}

