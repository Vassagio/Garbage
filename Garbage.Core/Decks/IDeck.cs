using System.Collections.Generic;
using Garbage.Core.Cards;
using Project.Utilities;

namespace Garbage.Core.Decks
{
    public interface IDeck: IDeepCloneable<IDeck>
    {
        ICard this[int index] { get; }

        int Count { get; }

        IEnumerator<ICard> GetEnumerator();
        ICard Pop();
        Deck Shuffle();
    }
}