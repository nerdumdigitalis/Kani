using System;
using System.Collections.Generic;
using System.Linq;
using Kani.Core.Entities;

namespace Kani.Core
{
    public static class DeckActions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public static List<Hand> Divide(this List<PlayingCard> list)
        {
            var result = new List<Hand>
                             {
                                 new Hand{PlayersHand = list.Take(13).OrderByDescending(card => card.Id).ToList()},
                                 new Hand{PlayersHand = list.Skip(13).Take(13).OrderByDescending(card => card.Id).ToList()},
                                 new Hand{PlayersHand = list.Skip(26).Take(13).OrderByDescending(card => card.Id).ToList()},
                                 new Hand{PlayersHand = list.Skip(39).Take(13).OrderByDescending(card => card.Id).ToList()}
                             };
            return result;
        }



    }
}
