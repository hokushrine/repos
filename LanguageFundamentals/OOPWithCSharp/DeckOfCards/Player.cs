using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    class Player
    {
        // Properties
        private string _name;
        private List<Card> _hand;

        // Constructor
        public Player(string name)
        {
            _name = name;
            _hand = new List<Card>();
        }


        // Methods
        public string Name => _name;

        public Card Draw(Deck deck)
        {
            Card theCard = deck.Deal();
            _hand.Add(theCard);
            return theCard;
        }

        // Discards the card at the specified index from the player's hand
        public Card Discard(int index)
        {
            if (index < _hand.Count)
            {
                var card = _hand[index];
                _hand.RemoveAt(index);
                return card;
            }
            else { return null; }
        }
    }
}
