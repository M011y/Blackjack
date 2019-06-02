using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Player
    {
        //properties: score, hand, name, bet
        public int Score { get; set; }
        public List<Card> Hand { get; set; }

        public string Name { get; set; }

        public int Bet { get; set; }

        //constructor1
        public Player (string name)
        {
            Name = name;
            Hand = new List<Card>();
            Score = 0;
            Bet = 0;
        }

        //constructor2
        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        //constructor3, empty constructor
        public Player()
        {
        }

        //tostring
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
