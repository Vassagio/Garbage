using Garbage.Core.Cards;
using Moq;

namespace Garbage.Core.Mocks
{
    public class MockCard: ICard
    {
        private readonly Mock<ICard> _mock = new Mock<ICard>();
        public Suit Suit => _mock.Object.Suit;
        public CardValue Value => _mock.Object.Value;
        public void Discard() => _mock.Object.Discard();
        public void Hide() => _mock.Object.Hide();
        public void Start() => _mock.Object.Start();
        public void Lock() => _mock.Object.Lock();
        public void Play() => _mock.Object.Play();
        public void Select() => _mock.Object.Select();

        public MockCard SuitReturns(Suit suit) {
            _mock.SetupGet(m => m.Suit).Returns(suit);
            return this;
        }

        public MockCard ValueReturns(CardValue cardValue)
        {
            _mock.SetupGet(m => m.Value).Returns(cardValue);
            return this;
        }
    }
}
