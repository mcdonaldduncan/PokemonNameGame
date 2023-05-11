using PokemonNameGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = PokemonNameGame.Data.Type;

namespace PokemonNameGame.GameServices
{
    public interface IGame
    {
        Type type { get; set; }
        Generation generation { get; set; }
        List<Pokemon> actual { get; set; }
        List<Pokemon> guessed { get; set; }
    }
}
