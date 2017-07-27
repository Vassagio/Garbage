using System.Collections;
using System.Collections.Generic;
using Garbage.Core.Cards;

namespace Garbage.Core.Decks.Dealers {
    public class Hand: IReadOnlyList<ICard> {
        private readonly List<ICard> _cards = new List<ICard>();
        public IEnumerator<ICard> GetEnumerator() => _cards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => _cards.Count;
        public ICard this[int index] => _cards[index];

        public void Add(ICard card) {
            _cards.Add(card);
        }
    }
}