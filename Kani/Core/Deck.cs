using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Kani.Core.Enums;
using System.Linq;

namespace Kani.Core
{
    public class Deck
    {
        
        public List<PlayingCard> NewDeck()
        {

            var deck = new List<PlayingCard>();
            for (int i = 0; i < 52; i++)
            {
                var card = new PlayingCard
                               {
                                   Suit = (i - i%13)/13,
                                   Id = i,
                                   CardNumber = i%13,
                                   CardName = ((CardNames)(i%13)) + "Of" + ((SuitNames)((i - i%13)/13)),
                                   BackgroundImageLayout = ImageLayout.Center,
                                   ImagePath = "c:/img/" + i + ".png",
                                   Image = Image.FromFile("c:/img/" + i + ".png"),
                                   BackImageVertical = Image.FromFile("c:/img/52.png"),
                                   BackImageHorizontal = Image.FromFile("c:/img/53.png"),
                                   Size = new Size(71, 96),
                               };
                deck.Add(card);
            }
            return deck;
        }

        public List<PlayingCard> GetCardsInSuit(int suit)
        {
            var cardsInSuit = NewDeck().Where(cards => cards.Suit == suit).ToList();
            foreach (var playingCard in cardsInSuit)
            {
                playingCard.BackgroundImage = playingCard.Image;
            }
            return cardsInSuit;
        }

    }
}
