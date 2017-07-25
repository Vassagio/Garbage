using System;
using Garbage.Core.Cards.CardStates;

namespace Garbage.Core.Tests.Cards.CardStates.CardStateHelper {
    public interface ICardStateWhen {
        ICardStateTransition When(Func<ICardState> predicate);
    }
}