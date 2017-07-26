using System;
using System.Linq.Expressions;
using Garbage.Utilities;

namespace Garbage.Core.Tests.Cards.StateHelper {
    public interface IStateWhen<T> where T: class, IDeepCloneable<T> {
        IStateTransition<T> When(Expression<Func<T>> predicate);
    }
}