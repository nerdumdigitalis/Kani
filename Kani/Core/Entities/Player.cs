using System.Collections.Generic;

namespace Kani.Core.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Points { get; set; }
        public Hand Hand { get; set; }
        public int Say { get; set; }
        public int RiskAffinity { get; set; }
    }
}
