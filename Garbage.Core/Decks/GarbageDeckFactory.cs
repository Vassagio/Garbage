﻿using System.Collections.Generic;
using System.Linq;
using Garbage.Core.Cards;
using Garbage.Utilities;

namespace Garbage.Core.Decks {
    public class GarbageDeckFactory : IDeckFactory
    {
        private readonly IShuffler _shuffler;

        public GarbageDeckFactory(IShuffler shuffler) => _shuffler = shuffler;

        public Deck Create() {            
            var cards = new List<Card>().Combine(
                Create(Suit.Club), 
                Create(Suit.Heart), 
                Create(Suit.Spade), 
                Create(Suit.Diamond));            
            return new Deck(cards, _shuffler);
        }

        private static IEnumerable<Card> Create(Suit suit) {
            var cards = new List<Card> {
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Ace).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Two).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Three).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Four).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Five).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Six).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Seven).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Eight).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Nine).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Ten).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Jack).IsWild().Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.Queen).Build(),
                Card.Initialize().WithSuit(suit).WithValue(CardValue.King).Build(),                
            };
            return cards;
        }
    }
}