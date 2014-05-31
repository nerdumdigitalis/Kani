using System.Collections.Generic;
using System.Drawing;

namespace Kani
{
    public class ScoreBoardPositions
    {
        public List<Point> PlayerNameLabelsPosition { get; private set; }
        public List<Point> PlayerScorePosition { get; private set; }
        public List<Point> PlayerSessionScorePosition { get; private set; }
        public List<Point> PlayerSessionNamePosition { get; private set; }
        public List<Point> TeamScorePosition { get; private set; }
        public List<Point> TeamLabelsPosition { get; private set; }


        public ScoreBoardPositions(ScoreBoard scoreBoard)
        {
            PlayerNameLabelsPosition = new List<Point>();
            PlayerScorePosition = new List<Point>();
            PlayerSessionScorePosition = new List<Point>();
            PlayerSessionNamePosition = new List<Point>();
            for(int i = 0; i < 4; i++)
            {
                PlayerNameLabelsPosition.Add(new Point(0, i*25 + 100));
                PlayerScorePosition.Add(new Point(100, i*25 + 100));
                PlayerSessionScorePosition.Add(new Point(100,i*25 + 300));
                PlayerSessionNamePosition.Add(new Point(0, i*25 + 300));
            }
        }

        

    }
}
