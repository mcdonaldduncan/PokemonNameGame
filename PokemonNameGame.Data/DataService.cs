using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonNameGame.Data
{
    public class DataService
    {
        private PROG455SP23Entities db = new PROG455SP23Entities();

        public List<Type> GetTypes()
        {
            return db.Types.ToList();
        }

        public List<Generation> GetGenerations()
        {
            return db.Generations.ToList();
        }

        public Type GetType(int ID)
        {
            return db.Types.Where(t => t.ID == ID).FirstOrDefault();
        }

        public Generation GetGeneration(int ID)
        {
            return db.Generations.Where(t => t.ID == ID).FirstOrDefault();
        }
    }
}
