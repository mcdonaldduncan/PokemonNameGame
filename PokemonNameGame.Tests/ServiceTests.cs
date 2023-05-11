using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonNameGame.Tests
{
    public class ServiceTests
    {
        [Fact]
        void TestCollectionDisplay()
        {
            DisplayService displayService = new DisplayService();
            List<Pokemon> temp = new List<Pokemon>()
            {
                new Pokemon() {Name = "test"},
                new Pokemon() {Name = "test"},
                new Pokemon() {Name = "test"},
                new Pokemon() {Name = "test"}
            };

            StringBuilder sb = new StringBuilder();
            foreach (var item in temp)
            {
                sb.AppendLine(item.Name);
            }

            Assert.Equal(sb.ToString(), displayService.FormatPokemonCollection(temp));
        }

        [Fact]
        void TestEmptyCollection()
        {
            DisplayService displayService = new DisplayService();
            List<Pokemon> temp = new List<Pokemon>();

            StringBuilder sb = new StringBuilder();
            foreach (var item in temp)
            {
                sb.AppendLine(item.Name);
            }

            Assert.Equal(sb.ToString(), displayService.FormatPokemonCollection(temp));
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(7,15)]
        [InlineData(10,25)]
        [InlineData(30,30)]
        void TestScoreFormat(int _guessed, int _actual)
        {
            DisplayService display = new DisplayService();
            GameServiceModel model = new GameServiceModel()
            {
                guessed = new Pokemon[_guessed].ToList(),
                actual = new Pokemon[_actual].ToList(),
            };

            Assert.Equal($"{_guessed}/{_actual}", display.FormatScore(model));
        }

        [Theory]
        [InlineData("Bulbasaur")]
        [InlineData("Charizard")]
        [InlineData("Squirtle")]
        [InlineData("Guybrush")]
        void TestGuessPokemonOnEmpty(string guess)
        {
            GameService gameService = new GameService(new GameServiceModel() { actual = new List<Pokemon>()});
            Assert.False(gameService.GuessPokemon(guess));
        }
    }
}
