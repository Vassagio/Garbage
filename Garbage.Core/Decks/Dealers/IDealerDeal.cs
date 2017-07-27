using System.Collections.Generic;

namespace Garbage.Core.Decks.Dealers {
    public interface IDealerDeal {
        (IEnumerable<Hand> hands, IDeck leftoverDeck) Deal();
    }
}