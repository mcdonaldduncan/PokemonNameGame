using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonNameGame.Data
{
    public class PokemonService
    {
        private PROG455SP23Entities db = new PROG455SP23Entities();

        public List<Pokemon> GetAll()
        {
            return db.Pokemons.ToList();
        }

        public List<Pokemon> GetFiltered(int TypeID, int GenID)
        {
            return db.Pokemons
                .Where(n => n.GenerationID == GenID && (n.TypeID == TypeID || n.AltTypeID == TypeID))
                .ToList();
        }
    }
}
