using System;
using Garbage.Utilities;

namespace Garbage.Core.Tests.Cards.StateHelper {
    public interface IStateTransition<T> where T : class, IDeepCloneable<T>
    {
        IStateAnd<T> TransitionTo<TConcreteType>(Func<TConcreteType> create) where TConcreteType : class, T;
    }
}