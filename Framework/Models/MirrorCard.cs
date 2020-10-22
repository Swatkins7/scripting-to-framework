using System;

namespace Framework.Models
{
    public class MirrorCard : Card
    {
        public override string Name {get; set;} = "Mirror";
        public override int Cost {get; set;} = 1;
        public override string Rarity { get; set; } = "Epic";//Debug: hold for now, let's see if we need this
        public override string Type {get; set;} = "Spell";
        public override string Arena {get; set;} = "Arena 12";
    }
}
