using Garbage.Utilities;

namespace Garbage.Core.Tests.Cards.StateHelper {
    public interface IStateAnd<T> where T : class, IDeepCloneable<T> {
        IStateWhen<T> And();
        void Assert();
    }
}