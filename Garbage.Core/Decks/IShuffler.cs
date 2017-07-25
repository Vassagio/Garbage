using System.Collections.Generic;
using Garbage.Core.Cards;

namespace Garbage.Core.Decks {
    public interface IShuffler {
        IEnumerable<ICard> Shuffle(IList<ICard> cards);
    }
}