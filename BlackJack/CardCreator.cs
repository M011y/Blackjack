using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class CardCreator
    {
        //create card
        public Card CreateCard(int index)
        {
            string house, face;

            house = GetHouse(index);
            face = GetFace(index);

            return new Card(index, house, face);
        }

        //get house
        public string GetHouse(int index)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string house = "house";

            if (index < 14)
            {
                house = "Spades \u2660";
            }

            else if (index < 27)
            {
                house = "Clubs \u2663";
            }

            else if (index < 40)
            {
                house = "Hearts \u2665";
            }

            else if (index < 53)
            {
                house = "Diamonds \u2666";
            }

            return house;

        }//end of get house

        //get face
        public string GetFace(int index)
        {
            string face = "face";

            if (index == 1 || index == 14 || index == 27 || index == 40)
            {
                face = "Ace";
            }

            else if (index == 2 || index == 15 || index == 28 || index == 41)
            {
                face = "2";
            }

            else if (index == 3 || index == 16 || index == 29 || index == 42)
            {
                face = "3";
            }

            else if (index == 4 || index == 17 || index == 30 || index == 43)
            {
                face = "4";
            }

            else if (index == 5 || index == 18 || index == 31 || index == 44)
            {
                face = "5";
            }

            else if (index == 6 || index == 19 || index == 32 || index == 45)
            {
                face = "6";
            }

            else if (index == 7 || index == 20 || index == 33 || index == 46)
            {
                face = "7";
            }

            else if (index == 8 || index == 21 || index == 34 || index == 47)
            {
                face = "8";
            }

            else if (index == 9 || index == 22 || index == 35 || index == 48)
            {
                face = "9";
            }

            else if (index == 10 || index == 23 || index == 36 || index == 49)
            {
                face = "10";
            }

            else if (index == 11 || index == 24 || index == 37 || index == 50)
            {
                face = "Jack";
            }

            else if (index == 12 || index == 25 || index == 38 || index == 51)
            {
                face = "Queen";
            }

            else if (index == 13 || index == 26 || index == 39 || index == 52)
            {
                face = "King";
            }

            return face;
        }
    }

}