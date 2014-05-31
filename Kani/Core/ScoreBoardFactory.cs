using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kani.Core
{
    public class ScoreBoardFactory
    {
        public ScoreBoard SetScoreBoard()
        {
            var scoreboard = new ScoreBoard
                                 {
                                     Name = "ScoreBoard",
                                     Size = new Size(300,500),
                                     Location = new Point(900, 150),
                                     BackColor = Color.DarkGoldenrod,
                                     PlayerNamesLabels = new List<Label>(),
                                     PlayerScore = new List<Label>(),
                                     PlayerSessionScore =  new List<Label>(),
                                     PlayerSessionNames = new List<Label>(),
                                 };

            var scoreboardLocation = new ScoreBoardPositions(scoreboard);

            for (int i = 0; i < 4; i++)
            {
                scoreboard.PlayerNamesLabels.Add( new Label
                                                           {
                                                               Name = "lblPlayer" + (i+1),
                                                               Text = "Player" + (i+1) + ": ",
                                                               Location = scoreboardLocation.PlayerNameLabelsPosition[i]
                                                           });
                scoreboard.PlayerScore.Add(new Label
                                               {
                                                   Name = "lblPlayerScore" + (i+1),
                                                   Text = "0",
                                                   Location = scoreboardLocation.PlayerScorePosition[i]
                                               });
                scoreboard.PlayerSessionScore.Add(new Label
                                                      {
                                                          Name = "lblPlayer" + (i+1) + "SessionScore",
                                                          Text = "0",
                                                          Location = scoreboardLocation.PlayerSessionScorePosition[i]
                                                      });
                scoreboard.PlayerSessionNames.Add(new Label
                                                      {
                                                          Name = "lblPlayer" + (i+1) + "SessionNames",
                                                          Text = "Player" + (i+1),
                                                          Location = scoreboardLocation.PlayerSessionNamePosition[i]
                                                      });
            }



            foreach (var label in scoreboard.PlayerNamesLabels)
            {
                scoreboard.Controls.Add(label);
            }
            foreach (var label in scoreboard.PlayerScore)
            {
                scoreboard.Controls.Add(label);
            }
            foreach (var label in scoreboard.PlayerSessionScore)
            {
                scoreboard.Controls.Add(label);
            }
            foreach (var label in scoreboard.PlayerSessionNames)
            {
                scoreboard.Controls.Add(label);
            }
                //lblPlayer1.Text = e.Value.Players[0].Name;
                //lblPlayer2.Text = e.Value.Players[1].Name;
                //lblPlayer3.Text = e.Value.Players[2].Name;
                //lblPlayer4.Text = e.Value.Players[3].Name;

                //_playerLabels.Add(lblPlayer1Score);
                //_playerLabels.Add(lblPlayer2Score);
                //_playerLabels.Add(lblPlayer3Score);
                //_playerLabels.Add(lblPlayer4Score);

                //_teamLabels.Add(lblTeam1Score);
                //_teamLabels.Add(lblTeam2Score);

                //lblTeam1_Player1.Text = e.Value.Game.Teams[0].Player1.Name;
                //lblTeam1_Player2.Text = e.Value.Game.Teams[0].Player2.Name;
                //lblTeam2_Player1.Text = e.Value.Game.Teams[1].Player1.Name;
                //lblTeam2_Player2.Text = e.Value.Game.Teams[1].Player2.Name;
                return scoreboard;
        }
    }
}
