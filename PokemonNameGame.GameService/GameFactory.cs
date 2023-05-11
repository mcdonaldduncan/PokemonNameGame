using PokemonNameGame.Data;
using PokemonNameGame.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokemonNameGame.GameServices
{
    public class GameFactory
    {
        PokemonService _pokemonService = new PokemonService();
        DataService _dataService = new DataService();
        DbLogger _logger = new DbLogger();

        public IGame CreateGame(int typeID, int genID)
        {
            IGame game;

            game = new GameServiceModel();

            game.type = _dataService.GetType(typeID);
            game.generation = _dataService.GetGeneration(genID);
            game.actual = _pokemonService.GetFiltered(typeID, genID);
            game.guessed = new List<Pokemon>();

            var context = new ValidationContext(game);
            var errors = new List<ValidationResult>();

            if (Validator.TryValidateObject(game, context, errors))
            {
                return game;
            }
            else
            {
                _logger.LogWarning("Error creating game in factory");
                return null;
            }
        }
    }
}
