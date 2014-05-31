using System.Collections.Generic;
using Kani.Core.Enums;

namespace Kani.Core.Entities
{
    public class Hand
    {
        public List<PlayingCard> PlayersHand { get; set; }
        public SuitNames MaxSuit {get; set; }
        public int MaxInSuit {get; set; }
        public int SureWins {get; set; }
        //public int Say {get; set; }

    }
}
