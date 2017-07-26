using Garbage.Core.Cards;
using Garbage.Core.Cards.CardBuilders;
using Xunit;

namespace Garbage.Core.Tests.Cards.CardBuilders {
    public class CardBuilderTest {
        [Fact]
        public void Build_StandardCardWithSuit() {
            var card = CardBuilder
                .NewCard()
                .WithSuit(Suit.Spade)
                .WithValue(CardValue.Ace)
                .Build();

            Assert.Equal(Suit.Spade, card.Suit);
        }

        [Fact]
        public void Build_StandardCardWithCardValue()
        {
            var card = CardBuilder
                .NewCard()
                .WithSuit(Suit.Diamond)
                .WithValue(CardValue.Ten)
                .Build();

            Assert.Equal(CardValue.Ten, card.Value);
        }

        [Fact]
        public void Build_WildCardWithSuit()
        {
            var card = CardBuilder
                .NewCard()
                .WithSuit(Suit.Heart)
                .WithValue(CardValue.Queen)
                .IsWild()
                .Build();

            Assert.Equal(Suit.Heart, card.Suit);
        }

        [Fact]
        public void Build_WildCardWithCardValue()
        {
            var card = CardBuilder
                .NewCard()
                .WithSuit(Suit.Club)
                .WithValue(CardValue.Two)
                .IsWild()
                .Build();

            Assert.Equal(CardValue.Two, card.Value);
        }
    }    
}