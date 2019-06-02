using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    //for getting each players scores
    class Score
    {

        //evaluate hand without aces
        public static int EvaluateHand(List<Card> hand)
        {
            int score = 0;

            //take aces out and store
            var aces = new List<Card>();
            var reducedHand = new List<Card>();
            foreach (Card card in hand)
            {
                if (card.Face.ToLower().Equals("ace"))
                {
                    aces.Add(card);
                }

                else { reducedHand.Add(card); }
            }

            //add up score
            foreach (Card card in reducedHand)
            {
                switch (card.Face)
                {
                    case "Jack":
                    case "Queen":
                    case "King":
                        score = score+10;
                        break;
                    default:
                        score = score + Convert.ToInt16(card.Face);
                        break;
                }
            }

            score = score + EvaluateAces(aces.Count, score);

            return score;
        }//end of evaluate hand method

        //evaluate aces
        private static int EvaluateAces(int noOfAces, int score)
        {
            int aceValue = 0;
            //if there are aces
            if (noOfAces > 0)
            {
                //if need 11 value to get closer to 21
                var distanceToBust = 21 - score;
                if (distanceToBust > 10 + noOfAces)
                {
                    aceValue = aceValue + 10;
                }

                aceValue = aceValue + noOfAces;
            }

            //if need 1 value to stop going bust
            return aceValue;

        }//end  evaluate aces method
    }
}
