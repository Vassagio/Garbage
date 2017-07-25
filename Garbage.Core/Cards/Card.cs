using Garbage.Core.Cards.CardBuilders;
using Garbage.Core.Cards.CardStates;

namespace Garbage.Core.Cards {
    public class Card : ICard
    {
        public Suit Suit { get; }
        public CardValue Value { get; }
        private ICardState _state;

        public static ICardSuitBuilder Initialize() => new CardBuilder();

        internal Card(Suit suit, CardValue cardValue, ICardState state) {
            Suit = suit;
            Value = cardValue;
            _state = state;
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

        public override string ToString() => $"{Value} of {Suit}s";
    }
}