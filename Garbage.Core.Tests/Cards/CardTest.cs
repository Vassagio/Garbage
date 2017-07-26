using Garbage.Core.Cards;
using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardTypeStates;
using Garbage.Core.Tests.Mocks;
using Xunit;

namespace Garbage.Core.Tests.Cards
{
    public class CardTest
    {
        [Fact]
        public void Initialize()
        {
            var card = Card.Create(default(Suit), default(CardValue));

            Assert.NotNull(card);
        }

        [Fact]
        public void Discard_VerifyDiscardStateCalled() {
            var state = new MockCardState();
            var card = BuildCard(state: state);

            card.Discard();

            state.VerifyDiscardCalled();
        }

        [Fact]
        public void Hide_VerifyHideStateCalled()
        {
            var state = new MockCardState();
            var card = BuildCard(state: state);

            card.Hide();

            state.VerifyHideCalled();
        }

        [Fact]
        public void Lock_VerifyLockStateCalled()
        {
            var state = new MockCardState();
            var card = BuildCard(state: state);

            card.Lock();

            state.VerifyLockCalled();
        }

        [Fact]
        public void Play_VerifyPlayStateCalled()
        {
            var state = new MockCardState();
            var card = BuildCard(state: state);

            card.Play();

            state.VerifyPlayCalled();
        }

        [Fact]
        public void Start_VerifyStartStateCalled()
        {
            var state = new MockCardState();
            var card = BuildCard(state: state);

            card.Start();

            state.VerifyStartCalled();
        }

        [Fact]
        public void Select_VerifySelectStateCalled()
        {
            var state = new MockCardState();
            var card = BuildCard(state: state);

            card.Select();

            state.VerifySelectCalled();
        }


        [Fact]
        public void Wild_VerifyWildCardTypeStateCalled()
        {
            var cardType = new MockCardTypeState();
            var card = BuildCard(cardType: cardType);

            card.Wild();

            cardType.VerifyWildCalled();
        }

        [Fact]
        public void ToString_StandardCard_ReturnsFormatText() {
            var cardType = new MockCardTypeState().ToStringReturns(" (CardType)");
            var card = BuildCard(Suit.Spade, CardValue.Jack, cardType: cardType);

            var actual = card.ToString();

            Assert.Equal("Jack of Spades (CardType)", actual);
        }

        private static Card BuildCard(Suit? suit = null, CardValue? cardValue = null, ICardState state = null, ICardTypeState cardType = null)
        {
            suit = suit ?? default(Suit);
            cardValue = cardValue ?? default(CardValue);
            state = state ?? new MockCardState();
            cardType = cardType ?? new MockCardTypeState();
            return new Card(suit.Value, cardValue.Value, state, cardType);
        }
    }
}