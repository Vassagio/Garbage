using System.Linq;
using Garbage.Core.Decks;
using Garbage.Core.Tests.Mocks;
using Xunit;

namespace Garbage.Core.Tests.Decks {
    public class GarbageDeckFactoryTest {
        [Fact]
        public void Initialize() {
            var deckFactory = BuildGarbageDeckFactory();

            Assert.IsAssignableFrom<IDeckFactory>(deckFactory);
        }

        [Fact]
        public void Create_ReturnsAnUnshuffledDeck() {
            var shuffler = new MockShuffler();
            var deckFactory = BuildGarbageDeckFactory(shuffler);

            var deck = deckFactory.Create();

            Assert.NotNull(deck);
            shuffler.VerifyShuffleNotCalled();
        }

        [Fact]
        public void Create_ReturnsADeckOf52Cards()
        {
            var deckFactory = BuildGarbageDeckFactory();

            var deck = deckFactory.Create();

            Assert.Equal(52, deck.Count);
        }

        [Fact]
        public void Create_ReturnsADeckWith4UniqueSuites()
        {
            var deckFactory = BuildGarbageDeckFactory();

            var deck = deckFactory.Create();

            Assert.Equal(4, deck.Select(d => d.Suit).Distinct().Count());
        }

        [Fact]
        public void Create_ReturnsADeckWith13UniqueValues()
        {
            var deckFactory = BuildGarbageDeckFactory();

            var deck = deckFactory.Create();

            Assert.Equal(13, deck.Select(d => d.Value).Distinct().Count());
        }

        private static GarbageDeckFactory BuildGarbageDeckFactory(IShuffler shuffler = null) => new GarbageDeckFactory(shuffler);
    }
}