using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonNameGame.Tests
{
    public class LoggerTests
    {
        [Fact]
        void TestConnectionString()
        {
            DbLogger logger = new DbLogger();
            Assert.NotEqual(string.Empty, logger.CheckConnection());
        }
    }
}
