using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Kani.Biz;
using Kani.Core.Entities;
using Kani.Core.Enums;

namespace Kani.Core
{
    public class TableFactory
    {
        public Table SetTable(Table table)
        {
            //var table = new Table
            //                {
            //                    Name = "table",
            //                    Size = new Size(800, 650),
            //                    BackColor = Color.LimeGreen,
            //                    Location = new Point(50, 50)
            //                };

            table.Name = "table";
            table.Size = new Size(800, 650);
            table.BackColor = Color.LimeGreen;
            table.Location = new Point(50,50);

            table.Controls.Clear();
            table.Deck = new Deck().NewDeck().Shuffle();
            table.Players = new List<Player>{
                                     new Player {Name = "player1"},
                                     new Player {Name = "player2"},
                                     new Player {Name = "player3"},
                                     new Player {Name = "player4"}
                                 };

            var hands = table.Deck.Divide();
            int i = 0;
            foreach(var player in table.Players)
            {
                player.Hand = hands[i++];
                player.Hand.MaxSuit = (SuitNames)player.Hand.PlayersHand.MaxSuit();
                player.Hand.MaxInSuit = player.Hand.PlayersHand.MostNumerousInSuit();
                player.Hand.SureWins = player.Hand.PlayersHand.GetSureWinners();
                player.Say = player.Hand.MaxInSuit + player.Hand.SureWins;
            }

            table.Position = new TablePosition(table);
            table = new Dealer().Deal(table);
            table.Laydown = new List<PlayingCard>();
            table.Turn = 0;
            table.Game = new Game {Teams = new List<Team>()};
            table.Hands = new List<Hand>();
            table.Game.Teams = new List<Team>{
                                                  new Team{Player1 = table.Players[0], Player2 = table.Players[1]},
                                                  new Team{Player1 = table.Players[2], Player2 = table.Players[3]}
                                              };
            table.Players.ForEach(player => player.Wins = 0);
            table.RequestedCards = new List<PlayingCard>();
            table.RequestedCard = new PlayingCard();
            table.IsRequest = true;
            table.SayLabels = new List<Label>();
            i = 0;
            foreach (var player in table.Players)
            {
                table.SayLabels.Add(new Label
                {
                    Location = table.Position.SayPosition[i++],
                    Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Size = new Size(100, 30),
                });
            }

            table.Player1Say = new TextBox
                                   {
                                       Size = new Size(30, 30),
                                       Name = "txtPlayer1Say",
                                       Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                       Location = table.Position.PlayerSayPosition,
                                   };

            table.Player1Say.KeyDown += delegate(object sender, KeyEventArgs e)
                                             {
                                                 if (e.KeyCode != Keys.Enter) return;
                                                 switch (e.KeyCode)
                                                 {
                                                     case Keys.D7:
                                                         table.SayLabels[0].Text = "Sjö";
                                                         break;
                                                     default:
                                                         return;

                                                 }
                                             };

            return table;
        }
    }
}
