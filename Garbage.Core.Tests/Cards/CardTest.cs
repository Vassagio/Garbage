using System;
using Garbage.Core.Cards;
using Garbage.Core.Cards.CardStates;
using Garbage.Core.Tests.Mocks;
using StandardStates =  Garbage.Core.Cards.CardStates.StandardCardStates;
using WildStates = Garbage.Core.Cards.CardStates.WildCardStates;
using Xunit;

namespace Garbage.Core.Tests.Cards
{
    public class CardTest
    {        
        [Fact]
        public void Initialize_Card() {
            var card = BuildCard();

            Assert.NotNull(card);
        }

        [Fact]
        public void Start_CallsStatesStart()
        {
            var cardState = new MockCardState();
            var card = BuildCard(cardState);

            card.Start();

            cardState.VerifyStartCalled();
        }

        [Fact]
        public void Select_CallsStatesSelect()
        {
            var cardState = new MockCardState();
            var card = BuildCard(cardState);

            card.Select();

            cardState.VerifySelectCalled();
        }

        [Fact]
        public void Play_CallsPlaySelect()
        {
            var cardState = new MockCardState();
            var card = BuildCard(cardState);

            card.Play();

            cardState.VerifyPlayCalled();
        }

        [Fact]
        public void Discard_CallsStatesDiscard()
        {
            var cardState = new MockCardState();
            var card = BuildCard(cardState);

            card.Discard();

            cardState.VerifyDiscardCalled();
        }

        [Fact]
        public void Hide_CallsStatesHide()
        {
            var cardState = new MockCardState();
            var card = BuildCard(cardState);

            card.Hide();

            cardState.VerifyHideCalled();
        }

        [Fact]
        public void Lock_CallsStatesLock()
        {
            var cardState = new MockCardState();
            var card = BuildCard(cardState);

            card.Lock();

            cardState.VerifyLockCalled();
        }

        private static Card BuildCard(ICardState cardState = null)
        {
            cardState = cardState ?? new MockCardState();
            return new Card(default(Suit), default(CardValue), cardState);
        }
    }
}
