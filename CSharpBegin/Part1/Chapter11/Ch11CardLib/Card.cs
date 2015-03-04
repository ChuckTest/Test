using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch11CardLib
{
    public class Card
    {
        private readonly Rank rank;
        private readonly Suit suit;

        private Card()
        {
            
        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public override string ToString()
        {
            return string.Format("The {0} of {1}s", rank, suit);
        }
    }
}
