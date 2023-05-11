using PokemonNameGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Type = PokemonNameGame.Data.Type;
using System.Net;

namespace PokemonNameGame.GameServices
{
    public class GameService
    {
        private GameServiceModel _currentGame;

        public GameService(IGame game)
        {
            _currentGame = (GameServiceModel)game;
        }

        public GameServiceModel GetGame()
        {
            return _currentGame;
        }


        public bool GuessPokemon(string guess)
        {
            if (_currentGame.actual.Any(p => p.Name.Equals(guess, StringComparison.OrdinalIgnoreCase)))
            {
                _currentGame.guessed.Add(_currentGame.actual.First(p => p.Name.Equals(guess, StringComparison.OrdinalIgnoreCase)));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckGameOver()
        {
            return _currentGame.guessed.Count >= _currentGame.actual.Count;
        }
    }
}
