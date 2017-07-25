using Garbage.Core.Cards.CardStates;
using Moq;

namespace Garbage.Core.Tests.Mocks {
    public class MockCardState : ICardState {
        private readonly Mock<ICardState> _mock = new Mock<ICardState>();
        public ICardState Start() => _mock.Object.Start();

        public ICardState Select() => _mock.Object.Select();

        public ICardState Play() => _mock.Object.Play();

        public ICardState Discard() => _mock.Object.Discard();

        public ICardState Hide() => _mock.Object.Hide();

        public ICardState Lock() => _mock.Object.Lock();

        public ICardState DeepClone() => _mock.Object.DeepClone();

        public MockCardState StartReturns(ICardState cardState) {
            _mock.Setup(m => m.Start()).Returns(cardState);
            return this;
        }

        public MockCardState SelectReturns(ICardState cardState)
        {
            _mock.Setup(m => m.Select()).Returns(cardState);
            return this;
        }

        public MockCardState PlayReturns(ICardState cardState)
        {
            _mock.Setup(m => m.Play()).Returns(cardState);
            return this;
        }

        public MockCardState DiscardReturns(ICardState cardState)
        {
            _mock.Setup(m => m.Discard()).Returns(cardState);
            return this;
        }

        public MockCardState HideReturns(ICardState cardState)
        {
            _mock.Setup(m => m.Hide()).Returns(cardState);
            return this;
        }

        public MockCardState LockReturns(ICardState cardState)
        {
            _mock.Setup(m => m.Lock()).Returns(cardState);
            return this;
        }

        public void VerifyStartCalled(int times = 1)
        {
            _mock.Verify(m => m.Start(), Times.Exactly(times));
        }

        public void VerifyStartNotCalled()
        {
            _mock.Verify(m => m.Start(), Times.Never);
        }

        public void VerifySelectCalled(int times = 1)
        {
            _mock.Verify(m => m.Select(), Times.Exactly(times));
        }

        public void VerifySelectNotCalled()
        {
            _mock.Verify(m => m.Select(), Times.Never);
        }

        public void VerifyPlayCalled(int times = 1)
        {
            _mock.Verify(m => m.Play(), Times.Exactly(times));
        }

        public void VerifyPlayNotCalled()
        {
            _mock.Verify(m => m.Play(), Times.Never);
        }

        public void VerifyDiscardCalled(int times = 1)
        {
            _mock.Verify(m => m.Discard(), Times.Exactly(times));
        }

        public void VerifyDiscardNotCalled()
        {
            _mock.Verify(m => m.Discard(), Times.Never);
        }

        public void VerifyHideCalled(int times = 1)
        {
            _mock.Verify(m => m.Hide(), Times.Exactly(times));
        }

        public void VerifyHideNotCalled()
        {
            _mock.Verify(m => m.Hide(), Times.Never);
        }

        public void VerifyLockCalled(int times = 1)
        {
            _mock.Verify(m => m.Lock(), Times.Exactly(times));
        }

        public void VerifyLockNotCalled()
        {
            _mock.Verify(m => m.Lock(), Times.Never);
        }
    }
}