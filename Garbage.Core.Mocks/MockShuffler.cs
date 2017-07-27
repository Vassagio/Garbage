using System.Collections.Generic;
using System.Linq;
using Garbage.Core.Cards;
using Garbage.Core.Decks;
using Moq;

namespace Garbage.Core.Mocks {
    public class MockShuffler : IShuffler {
        private readonly Mock<IShuffler> _mock = new Mock<IShuffler>();
        public IEnumerable<ICard> Shuffle(IList<ICard> cards) => _mock.Object.Shuffle(cards);

        public MockShuffler ShuffleReturns(IEnumerable<ICard> deck) {
            _mock.Setup(m => m.Shuffle(It.IsAny<IList<ICard>>())).Returns(deck.Reverse());
            return this;
        }

        public void VerifyShuffleCalled(IList<ICard> cards, int times = 1) {
            _mock.Verify(m => m.Shuffle(cards), Times.Exactly(times));
        }

        public void VerifyShuffleNotCalled() {
            _mock.Verify(m => m.Shuffle(It.IsAny<IList<ICard>>()), Times.Never);
        }
    }
}