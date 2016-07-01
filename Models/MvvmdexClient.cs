using System.Linq;
using System.Threading.Tasks;
using Jirapi;

namespace Mvvmdex.Models
{
	public class MvvmdexClient
	{
		PokeClient _client;
		public MvvmdexClient()
		{
			_client = new PokeClient();
		}

		public async Task<Pokemon> SearchForPokemon(string pokemonName)
		{
			// This could be anything, from a database to a connection to a web service:
			try
			{
				var pkmn = await _client.Get<Jirapi.Resources.Pokemon>(pokemonName);
				var species = await pkmn.Species.GetResource(_client);

				return new Pokemon
				{
					Id = pkmn.Id,
					Name = pkmn.Name,
					Description = species.FlavorTextEntries
					                     .FirstOrDefault(te => te.Language.Name == "en")
					                     .FlavorText.Replace("\n",""),
					Shape = species.Shape.Name
				};
			}
			catch(System.Exception e)
			{
				return null;
			}
		}
	}
}

