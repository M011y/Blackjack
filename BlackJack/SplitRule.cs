using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    //too complicated - did not use
    class SplitRule
    {
        //split evaluation
        public static bool IsSplitAllowed(List<Card> cards)
        {
            //if cards are same value/face
            if (cards.Count == 2)
            {
                Card card1 = cards[0];
                Card card2 = cards[1];

                if (card1.Face == card2.Face)
                {
                    return true;
                }

                else if (SpecialCard(card1.Face) && SpecialCard(card2.Face))
                {
                    return true;
                }

            }

            return false;

        }//end of split evaluation

        //specialcards
        private static bool SpecialCard(string face)
        {
            //listing all special cards with value of 10
            switch (face)
            {
                case "Jack":
                case "Queen":
                case "King":
                case "Ace":
                    return true;
                default:
                    return false;
            }//end of special cards
        }
    }
}
