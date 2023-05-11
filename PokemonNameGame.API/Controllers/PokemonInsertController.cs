using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonNameGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonInsertController : ControllerBase
    {
        InsertService insertService = new InsertService();

        // POST api/<PokemonInsertController>
        [HttpPost]
        public void Post(PokemonInsertModel model)
        {
            insertService.InsertPokemon(model);
        }

    }
}
