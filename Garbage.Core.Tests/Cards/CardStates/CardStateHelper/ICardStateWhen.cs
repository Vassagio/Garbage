using System;
using System.Linq.Expressions;
using Garbage.Core.Cards.CardStates;

namespace Garbage.Core.Tests.Cards.CardStates.CardStateHelper {
    public interface ICardStateWhen {
        ICardStateTransition When(Expression<Func<ICardState>> predicate);
    }
}