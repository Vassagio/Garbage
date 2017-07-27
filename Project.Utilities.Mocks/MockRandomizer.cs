using Moq;
using Project.Utilities.Randomizer;

namespace Project.Utilities.Mocks {
    public class MockRandomizer : IRandomizer {

        private readonly Mock<IRandomizer> _mock = new Mock<IRandomizer>();
        public int Next(int value) => _mock.Object.Next(value);

        public MockRandomizer NextReturns(int nextValue) {
            _mock.Setup(m => m.Next(It.IsAny<int>())).Returns(nextValue);
            return this;
        }

        public void VerifyNextCalled(int value, int times = 1) {
            _mock.Verify(m => m.Next(value), Times.Exactly(times));
        }

        public void VerifyNextNotCalled()
        {
            _mock.Verify(m => m.Next(It.IsAny<int>()), Times.Never);
        }
    }
}