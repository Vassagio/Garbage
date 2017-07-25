using System.Collections.Generic;
using Garbage.Core.Cards;

namespace Garbage.Core.Decks {
    public class FisherYatesShuffler : IShuffler {
        private readonly IRandomizer _randomizer;

        public FisherYatesShuffler(IRandomizer randomizer) => _randomizer = randomizer;

        public IEnumerable<ICard> Shuffle(IList<ICard> cards) {
            if (cards.Count == 1)
                return cards;

            for (var i = 0; i < cards.Count; i++) {
                var index = _randomizer.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[index];
                cards[index] = temp;
            }
            return cards;
        }
    }
}