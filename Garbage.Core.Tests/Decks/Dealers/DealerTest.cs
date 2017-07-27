using System;
using System.Linq;
using Garbage.Core.Decks;
using Garbage.Core.Decks.Dealers;
using Garbage.Core.Mocks;
using Xunit;

namespace Garbage.Core.Tests.Decks.Dealers
{
    public class DealerTest
    {
        [Fact]
        public void Initialize() {
            var dealer = BuildDealer();

            Assert.NotNull(dealer);
        }

        [Fact]
        public void Deal_FourPlayers_ReturnsFourHands() {
            var deck = new MockDeck().PopReturns(new MockCard(), 10);
            var dealer = BuildDealer(deck);

            var dealt = dealer.NumberOfPlayers(4)
                              .NumberOfCards(1)
                              .Deal();

            Assert.Equal(4, dealt.hands.Count());
        }

        [Fact]
        public void Deal_FiveCards_ReturnsAHandWithFiveCards()
        {
            var deck = new MockDeck().PopReturns(new MockCard(), 20);
            var dealer = new Dealer(deck);

            var dealt = dealer.NumberOfPlayers(1)
                              .NumberOfCards(5)
                              .Deal();

            Assert.Equal(5, dealt.hands.First().Count);
            deck.VerifyPopCalled(5);
        }

        [Theory]
        [InlineData(4, 10, 40)]
        [InlineData(3, 12, 36)]
        [InlineData(0, 0, 0)]
        public void Deal_MultipleCardsWithMultiplePeople_ReturnsMultipleHandWithCorrectNumberOf1Cards(int playerCount, int cardCount, int totalNumberOfCardsDealt)
        {
            var deck = new MockDeck().PopReturns(new MockCard(), 52);
            var dealer = new Dealer(deck);

            var dealt = dealer.NumberOfPlayers(playerCount)
                              .NumberOfCards(cardCount)
                              .Deal();

            Assert.Equal(totalNumberOfCardsDealt, dealt.hands.Sum(h => h.Count));
            deck.VerifyPopCalled(totalNumberOfCardsDealt);
        }

        [Theory]
        [InlineData(6, 5, 52, 22)]
        [InlineData(1, 1, 36, 35)]
        public void Deal_MultipleCardsWithMultiplePeople_ReturnsLeftoverDeck(int playerCount, int cardCount, int startingCount, int leftoverCount)
        {            
            var deck = new MockDeck().PopReturns(new MockCard(), startingCount);
            var dealer = new Dealer(deck);

            var dealt = dealer.NumberOfPlayers(playerCount)
                              .NumberOfCards(cardCount)
                              .Deal();

            Assert.NotEqual(deck, dealt.leftoverDeck);
        }

        [Fact]        
        public void Deal_WhenNotEnoughCards_ThrowsArgumentException()
        {
            var deck = new MockDeck().PopReturns(new MockCard(), 2);
            var dealer = new Dealer(deck);            

            var exception = Assert.Throws<ArgumentException>(() => dealer.NumberOfPlayers(2)
                                                                         .NumberOfCards(7)
                                                                         .Deal());

            Assert.Equal("Deck does not contain 14 card(s).  Only 2 card(s) exist.", exception.Message);
            deck.VerifyCountCalled(2);

        }

        private static Dealer BuildDealer(IDeck deck = null) {
            deck = deck ?? new MockDeck();
            return new Dealer(deck);
        }
    }
}
