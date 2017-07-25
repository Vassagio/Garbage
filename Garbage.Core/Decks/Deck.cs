using System.Collections;
using System.Collections.Generic;
using Garbage.Core.Cards;

namespace Garbage.Core.Decks {
    public class Deck : IReadOnlyList<ICard> {
        private readonly IShuffler _shuffler;
        private readonly List<ICard> _cards;

        public Deck(IEnumerable<ICard> cards, IShuffler shuffler) {
            _cards = new List<ICard>(cards);
            _shuffler = shuffler;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<ICard> GetEnumerator() => _cards.GetEnumerator();

        public Deck Shuffle() => new Deck(_shuffler.Shuffle(_cards), _shuffler);
        public int Count => _cards.Count;
        public ICard this[int index] => _cards[index];
    }
}