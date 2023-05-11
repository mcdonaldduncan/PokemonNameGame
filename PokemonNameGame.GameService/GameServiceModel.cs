using PokemonNameGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = PokemonNameGame.Data.Type;

namespace PokemonNameGame.GameServices
{
    public class GameServiceModel : IGame
    {
        [CustomRequired]
        public Type type { get; set; }

        [CustomRequired]
        public Generation generation { get; set; }

        public List<Pokemon> actual { get; set; }

        public List<Pokemon> guessed { get; set; }

    }
}
