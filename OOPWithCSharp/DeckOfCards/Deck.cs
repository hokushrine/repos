using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    class Deck
    {
        // Properties
        private List<Card> _cards = new List<Card>();

        // Constructor
        public Deck()
        {
            
        }

        // Methods
        public List<Card> Reset()
        {
            _cards.Clear();
            for (int i = 0; i < 4; i++) // iterate through suits
            {
                int j = 1;
                while (j < 14)
                {
                    _cards.Add(new Card(Card.Suits[i], j));
                    j++;
                }
            }

            return _cards;
        }

        public Card Deal()
        {
            Card theCard = _cards[0];
            _cards.RemoveAt(0);
            return theCard;
        }


        // Randomly reorders the deck's cards
        public void Shuffle()
        {
            List<Card> cardsToShuffle = _cards;
            List<Card> shuffled = new List<Card>();
            var rand = new Random();
            while (cardsToShuffle.Count > 0)
            {
                int index = rand.Next(0, cardsToShuffle.Count);
                shuffled.Add(cardsToShuffle[index]);
                cardsToShuffle.RemoveAt(index);
            }
            this._cards = shuffled;
        }
    }
}
