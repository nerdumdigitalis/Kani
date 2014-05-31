using System;
using System.Collections.Generic;
using System.Linq;
using Kani.Core;
using Kani.Core.Enums;

namespace Kani.Biz
{
    public static class BizExtensions
    {
        public static PlayingCard HighestCard(this List<PlayingCard> list)
        {
            return list.Find(x => x.CardNumber == list.Max(y => y.CardNumber));
        }

        public static PlayingCard LowestCard(this List<PlayingCard> list)
        {
            return list.Find(x => x.CardNumber == list.Min(y => y.CardNumber));
        }

        public static Boolean IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true;
            return !source.Any();
        }

        public static Boolean HasLaydownSuit(this List<PlayingCard> hand, int laydownsuit)
        {
            return hand.Any(card => card.Suit == laydownsuit);
        }

        /// <summary>
        /// Returns how many cards are in the most numerous suit
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static int MostNumerousInSuit(this List<PlayingCard> hand)
        {
            
            return (from cards in hand
                     group cards by cards.Suit
                     into g
                     select g.Count()).Max();
        }

        /// <summary>
        /// Returns the suit that is most numerous in hand, 0 for hearts, 1 for spades, 2 for diamonds and 3 for clubs
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static int MaxSuit(this List<PlayingCard> hand)
        {
            var suits = hand.GroupBy(card => card.Suit).Select(group => group.Count()).Reverse().ToList();
            return suits.IndexOf(suits.Max());
        }

        public static int GetSureWinners(this List<PlayingCard> hand)
        {

            return 3;
        }

        public static List<PlayingCard> GetRequestCards(this int suit, List<PlayingCard> hand)
        {
            var cardsInSuit = new Deck().GetCardsInSuit(suit);
            foreach(var playingCard in hand.Where(cards => cards.Suit == suit))
            {
                cardsInSuit.RemoveAll(cards => cards.CardNumber == playingCard.CardNumber);
            }
            return cardsInSuit;
        }

        public static bool HasRequestedCard(this Table table)
        {
            var hand = table.Players[table.Turn].Hand.PlayersHand;
            return hand.Exists(card => card.Id == table.RequestedCard.Id);
        }
    }
}
