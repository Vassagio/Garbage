using System;
using System.Collections.Generic;

namespace Garbage.Core.Decks.Dealers
{
    public class Dealer: IDealerPlayers, IDealerHands, IDealerDeal
    {
        private readonly IDeck _deck;
        private int _cardCount;
        private readonly List<Hand> _hands = new List<Hand>();

        public Dealer(IDeck deck) => _deck = deck.DeepClone();

        public IDealerHands NumberOfPlayers(int playerCount) {
            for (var i = 0; i < playerCount; i++) 
                _hands.Add(new Hand());
            return this;
        }

        public IDealerDeal NumberOfCards(int cardCount) {
            _cardCount = cardCount;
            return this;
        }

        private void BuildHands() {
            for (var i = 0; i < _cardCount; i++)
                foreach (var hand in _hands)
                    hand.Add(_deck.Pop());
        }        

        public (IEnumerable<Hand> hands, IDeck leftoverDeck) Deal() {            
            var totalCardsNeeded = _hands.Count * _cardCount;
            if (totalCardsNeeded > _deck.Count)
                throw new ArgumentException($"Deck does not contain {totalCardsNeeded} card(s).  Only {_deck.Count} card(s) exist.");

            BuildHands();

            return (_hands, _deck);
        }
    }
}
