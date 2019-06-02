using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Card
    {
        //list properties: index, house, face
        public int Index { get; set; }
        public string House { get; set; }
        public string Face { get; set; }

        //constructor1 with all properties
        public Card(int index, string house, string face)
        {
            House = house;
            Face = face;
            Index = index;
        }

        //constructor2 with main properties
        public Card(string house, string face)
        {
            House = house;
            Face = face;
        }

        //constructor3 empty
        public Card()
        {

        }

        //tostring method
        public override string ToString()
        {
            return base.ToString();
        }
    }
}