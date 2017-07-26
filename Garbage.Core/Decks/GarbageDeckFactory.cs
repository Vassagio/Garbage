using System.Collections.Generic;
using System.Linq;
using Garbage.Core.Cards;
using Garbage.Core.Cards.CardBuilders;
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
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Ace).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Two).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Three).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Four).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Five).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Six).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Seven).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Eight).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Nine).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Ten).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Jack).IsWild().Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.Queen).Build(),
                CardBuilder.NewCard().WithSuit(suit).WithValue(CardValue.King).Build(),                
            };
            return cards;
        }
    }
}