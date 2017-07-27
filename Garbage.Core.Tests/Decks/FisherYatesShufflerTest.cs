using System.Collections.Generic;
using System.Linq;
using Garbage.Core.Cards;
using Garbage.Core.Decks;
using Garbage.Core.Mocks;
using Project.Utilities.Mocks;
using Project.Utilities.Randomizer;
using Xunit;

namespace Garbage.Core.Tests.Decks {
    public class FisherYatesShufflerTest {
        [Fact]
        public void Initialize() {
            var shuffler = BuildShuffler();

            Assert.IsAssignableFrom<IShuffler>(shuffler);
        }

        [Fact]
        public void Shuffle_NoCards_ReturnsEmptyDeck() {
            var randomizer = new MockRandomizer();
            var shuffler = BuildShuffler(randomizer);

            var deck = shuffler.Shuffle(new List<ICard>());

            Assert.Empty(deck);
            randomizer.VerifyNextNotCalled();
        }

        [Fact]
        public void Shuffle_OneCard_ReturnsDeckWithOneCard()
        {
            var cards = new List<ICard> { new MockCard() };
            var randomizer = new MockRandomizer();
            var shuffler = BuildShuffler(randomizer);

            var deck = shuffler.Shuffle(cards);

            Assert.Equal(cards, deck);
            randomizer.VerifyNextNotCalled();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(52)]
        public void Shuffle_MultipleCards_ReturnsDeckWithMultipleCards(int cardCount)
        {
            var cards = Enumerable.Repeat(new MockCard(), cardCount).ToList<ICard>();
            var randomizer = new MockRandomizer().NextReturns(1);
            var shuffler = BuildShuffler(randomizer);

            var deck = shuffler.Shuffle(cards);

            Assert.Equal(cards, deck);            
            randomizer.VerifyNextCalled(cardCount);
        }

        private static FisherYatesShuffler BuildShuffler(IRandomizer randomizer = null) {
            randomizer = randomizer ?? new MockRandomizer();
            return new FisherYatesShuffler(randomizer);
        }
    }
}