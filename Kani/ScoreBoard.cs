using System.Collections.Generic;
using System.Windows.Forms;

namespace Kani
{
    public class ScoreBoard : Panel
    {
        public List<Label> PlayerNamesLabels { get; set; }
        public List<Label> PlayerScore { get; set; }
        public List<Label> PlayerSessionScore { get; set; }
        public List<Label> PlayerSessionNames { get; set; }
        public List<Label> TeamScore { get; set; }
        public List<Label> TeamLabels { get; set; }
    }
}
