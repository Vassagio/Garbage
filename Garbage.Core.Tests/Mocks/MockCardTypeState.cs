using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardTypeStates;
using Moq;

namespace Garbage.Core.Tests.Mocks {
    public class MockCardTypeState : ICardTypeState {
        public IPlayedCardState PlayedCardState => _mock.Object.PlayedCardState;
        private readonly Mock<ICardTypeState> _mock = new Mock<ICardTypeState>();
        public ICardTypeState Standard() => _mock.Object.Standard();
        public ICardTypeState Wild() => _mock.Object.Wild();
        public ICardTypeState DeepClone() => _mock.Object.DeepClone();
        public override string ToString() => _mock.Object.ToString();

        public void VerifyWildCalled(int times = 1) {
            _mock.Verify(m => m.Wild(), Times.Exactly(times));
        }

        public MockCardTypeState ToStringReturns(string cardTypeText) {
            _mock.Setup(m => m.ToString()).Returns(cardTypeText);
            return this;
        }
    }
}