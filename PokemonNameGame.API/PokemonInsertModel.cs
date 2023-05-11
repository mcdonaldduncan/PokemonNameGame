using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonNameGame.API
{
    public class PokemonInsertModel
    {
        public string Name { get; set; }
        public int TypeID { get; set; }
        public int? AltTypeID { get; set; }
        public int GenerationID { get; set; }
    }
}