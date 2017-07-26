using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards {    
    public class Card : ICard
    {
        public Suit Suit { get; }
        public CardValue Value { get; }
        private ICardState _state;
        private ICardTypeState _type;

        public static Card Create(Suit suit, CardValue cardValue) {
            var cardType = new StandardCardType();
            return new Card(suit, cardValue, new Started(cardType), cardType);
        } 

        internal Card(Suit suit, CardValue cardValue, ICardState state, ICardTypeState cardType) {
            Suit = suit;
            Value = cardValue;
            _state = state;
            _type = cardType;
        }

        public void Start() {
            _state = _state.Start();
        }

        public void Select() {
            _state = _state.Select();
        }

        public void Play() {
            _state = _state.Play();
        }

        public void Discard() {
            _state = _state.Discard();
        }

        public void Hide() {
            _state = _state.Hide();
        }

        public void Lock() {
            _state = _state.Lock();
        }
        
        public void Wild() {
            _type = _type.Wild();
        }

        public override string ToString() => $"{Value} of {Suit}s{_type}";
    }
}