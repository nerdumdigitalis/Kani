using System;
using System.Linq;
using Kani.Core;

namespace Kani.Biz
{
    public class GameBiz
    {

        public PlayingCard Play(Table table)
        {
            var theLaydown = table.Laydown;
            var hand = table.Players[table.Turn].Hand.PlayersHand;
            var laydownSuit = table.LaydownSuit;
            var requestedCard = table.RequestedCard;

            if (hand.Exists(card => card.Id == requestedCard.Id))
            {
                return hand.Find(card => card.Id == requestedCard.Id);
            }
            if (table.Laydown.IsEmpty())
            {
                return hand.HighestCard();
                //if(table.IsFirstRound)
                //{
                //    // TODO: Skila lægsta spilinu í lengstu sortinni og ef tvær sortir eru jafn langar þá betri sortinni, ef báðar jafngóðar, annarri sortinni
                //    return hand.Where(cards => cards.Suit == hand.MaxSuit()).ToList().LowestCard();
                //}
                //else
                //{
                //    return hand.HighestCard();
                //}
            }
            var highestCardInLaydownSuit = theLaydown.Where(card => card.Suit == laydownSuit).Max(card => card.CardNumber); //Athugar hvert hæsta spilið er í borðinu í þeirri sort sem er í borðinu
            var handSuit = hand.Where(cards => cards.Suit == laydownSuit); //öll spilin af sömu sort og eru í borðina hjá spilara
            if (!handSuit.IsEmpty())
            {
                // Hér er ljóst að spilari á einhver spil í borðsortinni
                var maxinsuit = handSuit.Max(card => card.CardNumber); //Finnum hæsta spilið sem spilari á í borðsortinni
                if (maxinsuit > highestCardInLaydownSuit)
                {
                    //Spilari spilar út lægsta spilinu sínu í borðsortinni, sem þó er hærra en hæsta spilið á borðinu
                    return handSuit.First(card => card.CardNumber > highestCardInLaydownSuit);
                }
                else
                {
                    //Hér er ljóst að spilarinn á spil í borðsortinni, enn ekki hærra en nógu hátt til að taka slaginn
                    //skilar lægsta spilinu í borðsortinni
                    return handSuit.Last();
                }
            }
            else
            {
                //Hérna er svo komið að spilari átti ekkert spil í borðsortinni
                //Leggur niður lægsta spilið sitt
                return hand.LowestCard();

            }
        }
        /// <summary>
        /// Returns the lowest playingcard in the most numerous suit
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public PlayingCard GetRequestCard(Table table)
        {
            var requestPlayer = table.Players.FirstOrDefault(player => player.Say != 0);
            if (requestPlayer != null)
            return requestPlayer.Hand.PlayersHand.Where(card => card.Suit == (int) requestPlayer.Hand.MaxSuit).ToList().LowestCard();
            throw new Exception("Error in GetRequestCard");
        }


       public PlayingCard GetRequestedCard(Table table)
       {
           var requestSuit = table.Players[table.Turn].Hand.PlayersHand.Where(cards => cards.Suit == table.RequestCard.Suit).ToList();
           var highestCard = requestSuit.HighestCard();
           var suit = new Deck().GetCardsInSuit(highestCard.Suit);
           foreach (var playingCard in requestSuit)
           {
               suit.Remove(suit.Find(card => card.Id == playingCard.Id));
           }

           return suit.HighestCard();
       }

    }

}
