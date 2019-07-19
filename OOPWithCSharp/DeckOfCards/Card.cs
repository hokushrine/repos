using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    class Card
    {

        // Properties
        private string _stringVal;
        private int _value;
        private string _suit; // singular card suit

        public static string[] Suits = new string[4] {"Clubs", "Spades", "Hearts", "Diamonds"};

        public Card(string s, int val)
        {
            switch (val)
            {
                case 11:
                    _stringVal = "Jack";
                    break;
                case 12:
                    _stringVal = "Queen";
                    break;
                case 13:
                    _stringVal = "King";
                    break;
                case 1:
                    _stringVal = "Ace";
                    break;
                default:
                    _stringVal = val.ToString();
                    break;
            }

            _suit = s;
            _value = val;
        }

        public void SayCard()
        {
            System.Console.WriteLine("The {0} of {1}", _suit, _stringVal);
        }
    }
}