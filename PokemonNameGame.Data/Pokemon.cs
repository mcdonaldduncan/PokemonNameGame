//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokemonNameGame.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pokemon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
        public Nullable<int> AltTypeID { get; set; }
        public int GenerationID { get; set; }
    
        public virtual Generation Generation { get; set; }
        public virtual Type Type { get; set; }
        public virtual Type Type1 { get; set; }
    }
}
