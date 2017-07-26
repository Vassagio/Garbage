using System;
using Garbage.Core.Cards.CardTypeStates;
using Garbage.Core.Tests.Cards.StateHelper;
using Xunit;

namespace Garbage.Core.Tests.Cards.CardTypeStates {
    public class CardTypeStatesTest {
        private static readonly Func<StandardCardType> STANDARD = () => State.Create<StandardCardType>();
        private static readonly Func<WildCardType> WILD = () => State.Create<WildCardType>();

        [Fact]
        public void Initialize() {
            var cardType = new StandardCardType();

            Assert.IsAssignableFrom<ICardTypeState>(cardType);
        }

        [Fact]
        public void Standard_ChangeStates()
        {
            var state = STANDARD();

            StateTests<ICardTypeState>.For(state)
                                      .When(() => state.Wild()).TransitionTo(WILD).And()
                                      .When(() => state.Standard()).TransitionTo(STANDARD)
                                      .Assert();
        }

        [Fact]
        public void Wild_ChangeStates()
        {
            var state = WILD();

            StateTests<ICardTypeState>.For(state)
                                      .When(() => state.Wild()).TransitionTo(WILD).And()
                                      .When(() => state.Standard()).TransitionTo(STANDARD)
                                      .Assert();
        }
    }
}