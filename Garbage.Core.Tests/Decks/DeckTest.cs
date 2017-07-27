using System.Collections.Generic;
using Garbage.Core.Cards;
using Garbage.Core.Decks;
using Garbage.Core.Mocks;
using Xunit;

namespace Garbage.Core.Tests.Decks
{
    public class DeckTest
    {
        [Fact]
        public void Initialize() {
            var deck = BuildDeck();

            Assert.NotNull(deck);
        }

        [Fact]
        public void Shuffle_ReturnsAShuffledDeck() {
            var card1 = new MockCard().SuitReturns(Suit.Club).ValueReturns(CardValue.King);
            var card2 = new MockCard().SuitReturns(Suit.Heart).ValueReturns(CardValue.Nine);
            var shuffledDeck = new Deck(new List<MockCard> { card1, card2 }, new MockShuffler());
            var shuffler = new MockShuffler().ShuffleReturns(shuffledDeck);
            var deck = BuildDeck(new List<MockCard>(), shuffler);

            var actual = deck.Shuffle();

            Assert.Equal(new List<MockCard> { card2, card1 }, actual);
        }

        [Fact]
        public void Shuffle_ReturnsADeckThatDoesNotEqualOriginal()
        {
            var card1 = new MockCard().SuitReturns(Suit.Spade).ValueReturns(CardValue.Four);
            var card2 = new MockCard().SuitReturns(Suit.Diamond).ValueReturns(CardValue.Three);
            var originalDeck = new List<MockCard> { card1, card2 };            
            var shuffler = new MockShuffler().ShuffleReturns(originalDeck);
            var deck = BuildDeck(new List<MockCard>(), shuffler);

            var actual = deck.Shuffle();

            Assert.NotEqual(originalDeck, actual);
        }

        [Fact]
        public void Get_ReturnsCard()
        {
            var card1 = new MockCard().SuitReturns(Suit.Spade).ValueReturns(CardValue.Seven);
            var card2 = new MockCard().SuitReturns(Suit.Diamond).ValueReturns(CardValue.Queen);
            var originalDeck = new List<MockCard> { card1, card2 };
            
            var deck = BuildDeck(originalDeck, new MockShuffler());

            var actual = deck[0];

            Assert.Equal(card1, actual);
        }

        [Fact]
        public void Count_ReturnsCorrectNumberOfCards()
        {
            var card1 = new MockCard().SuitReturns(Suit.Spade).ValueReturns(CardValue.Eight);
            var card2 = new MockCard().SuitReturns(Suit.Diamond).ValueReturns(CardValue.Ace);
            var card3 = new MockCard().SuitReturns(Suit.Club).ValueReturns(CardValue.Six);
            var originalDeck = new List<MockCard> { card1, card2, card3 };

            var deck = BuildDeck(originalDeck, new MockShuffler());            
            
            Assert.Equal(3, deck.Count);
        }

        private static Deck BuildDeck(IEnumerable<ICard> cards = null, IShuffler shuffler = null) {
            cards = cards ?? new List<ICard>();
            shuffler = shuffler ?? new MockShuffler();
            return new Deck(cards, shuffler);
        }
    }
}
