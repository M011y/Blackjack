using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    //create the dealer
    class Dealer
    {
        //properties: player(score), deck, hand
        public Player Player { get; set; }
        private List<Card> Deck { get; set; }
        public List<Card> Hand { get; set; }

        //constructor1
        public Dealer(Player player, List<Card> deck, List<Card> hand)
        {
            Player = player;
            Deck = deck;
            Hand = hand;
        }

        //constructor2
        public Dealer(Player player, List<Card> hand)
        {
            Player = player;
            Hand = hand;
            Deck = new List<Card>();
            ShuffledDeck();
        }

        //constructor3 empty constructor
        public Dealer()
        {

        }

        //tostring
        public override string ToString()
        {
            return base.ToString();

        }
        
        /// <summary>
        /// get shuffled deck by placing cards in a random order by tracking the index used to create the cards and
        /// rejecting anything that has a previously used index, repeating process until deck is filled
        /// </summary>
        public void ShuffledDeck()
        {  
            int index;
            Random rand = new Random();
            var cardCreator = new CardCreator();
            int[] indexesUsed = new int[52];

            for (int i = 0; i < 52; i++)
            {
                index = GetUniqueRandomCard(rand, indexesUsed);
                Deck.Add(cardCreator.CreateCard(index));
                indexesUsed[i] = index;
            }

        }//end of shuffled deck method

        //get unique random card - checks if random number already exists within array
        public int GetUniqueRandomCard(Random rand, int[] used)
        {
            int newIndex = rand.Next(1, 53);
            if (ArrayMethod.ArrayContainsValue(used, newIndex))
            {
                return GetUniqueRandomCard(rand, used);
            }

            else
            {
                return newIndex;
            }
        }//end of unique card method

        //deal
        public Card Deal()
        {
            Card card = Deck[0];
            //remove card from top of deck so same card cannot be drawn
            Deck.RemoveAt(0);
            return card;
        }//end deal
    }
}
