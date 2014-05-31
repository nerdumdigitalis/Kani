namespace Kani.Core.Entities
{
    public class Team
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Score
        {
            get { return Player1.Wins + Player2.Wins; }
        }
    }
}
