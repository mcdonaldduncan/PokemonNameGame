using PokemonNameGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonNameGame.GameServices
{
    public class DisplayService
    {
        public string FormatPokemonCollection(List<Pokemon> collection)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pokemon in collection)
            {
                sb.AppendLine(pokemon.Name);
            }

            return sb.ToString();
        }

        public string FormatScore(GameServiceModel model)
        {
            return $"{model.guessed.Count}/{model.actual.Count}";
        }
    }
}
