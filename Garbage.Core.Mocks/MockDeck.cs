using System.Collections.Generic;
using System.Linq;
using Garbage.Core.Cards;
using Garbage.Core.Decks;
using Moq;

namespace Garbage.Core.Mocks {
    public class MockDeck : IDeck {
        
        public int Count => _mock.Object.Count;
        public ICard this[int index] => _mock.Object[index];
        private readonly Mock<IDeck> _mock = new Mock<IDeck>();
        private List<ICard> _cards;             

        public IEnumerator<ICard> GetEnumerator() => _mock.Object.GetEnumerator();

        public ICard Pop() {
            _cards.Remove(_cards.First());            
            return _mock.Object.Pop();            
        }

        public Deck Shuffle() => _mock.Object.Shuffle();

        public IDeck DeepClone() => _mock.Object.DeepClone();

        public MockDeck PopReturns(ICard card, int count)
        {            
            _cards = new List<ICard>(Enumerable.Repeat(new MockCard(), count));
            return PopReturns(_cards);
        }
        private MockDeck PopReturns(IEnumerable<ICard> cards) {
            var queue = new Queue<ICard>(cards);
            _mock.Setup(m => m.Pop()).Returns(queue.Dequeue);
            _mock.Setup(m => m.Count).Returns(_cards.Count());
            _mock.Setup(m => m.DeepClone()).Returns(this);
            return this;
        }            

        public void VerifyPopCalled(int times = 1) {
            _mock.Verify(m => m.Pop(), Times.Exactly(times));
        }

        public void VerifyCountCalled(int times = 1) {
            _mock.Verify(m => m.Count, Times.Exactly(times));
        }
    }
}