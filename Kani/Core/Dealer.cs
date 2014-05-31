using System.Collections.Generic;
using Kani.Core.Enums;

namespace Kani.Core
{
    public class Dealer
    {

        public Table Deal(Table table)
        {
            int i = 0;
            int j = 0;

            //table.Hands = table.Deck.Divide();
            //int player = 0;
            //foreach (var hand in table.Hands)
            //{
            //    table.Players[player++].Hand = hand;
            //}

            foreach (var player in table.Players)
            {
                foreach (var card in player.Hand.PlayersHand)
                {
                    card.Location = table.Position.GetDealingPosition(j, i);

                    if (j == 0)
                    {
                        card.BackgroundImage = card.Image;
                    }
                    if (j == 1 || j == 3)
                    {
                        //card.BackgroundImage = card.BackImageHorizontal;
                        card.BackgroundImage = card.Image;

                    }
                    if (j == 2)
                    {
                        //card.BackgroundImage = card.BackImageVertical;
                        card.BackgroundImage = card.Image;

                    }
                    card.Size = card.BackgroundImage.Size;
                    card.BelongsTo = j;
                    table.Controls.Add(card);
                    i++;
                }
                i = 0;
                //table.Players[j] = 
                j++;
            }

            return table;
        }
    }
}
