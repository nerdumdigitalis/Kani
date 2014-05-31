using System.Collections.Generic;

namespace Kani.Core.Entities
{
    public class Game
    {
        public int Trump { get; set; }
        public int Say { get; set; }
        public List<Team> Teams { get; set; }

    }
}
