using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Kani.Core;
using Kani.Core.Entities;

namespace Kani
{
    public class Table : Panel
    {
        public List<Player> Players { get; set; }
        public TablePosition Position { get; set; }
        public List<Hand> Hands { get; set; }
        public List<PlayingCard> Laydown { get; set; }
        public int LaydownSuit { get; set; }
        public List<PlayingCard> Deck { get; set; }
        public Game Game { get; set; }
        public int Turn { get; set; }
        public List<PlayingCard> RequestedCards { get; set; }
        public PlayingCard RequestedCard { get; set; }
        public PlayingCard RequestCard { get; set; }
        public bool IsRequest { get; set; }
        public List<Label> SayLabels { get; set; }
        public TextBox Player1Say { get; set; }
    }
}
