using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Garbage.Core.Cards.CardStates;
using Garbage.Utilities;

namespace Garbage.Core.Tests.Cards.CardStates.CardStateHelper {
    public class CardStateTests : ICardStateWhen, ICardStateTransition, ICardStateAnd {
        internal struct TestCase {
            public TestCase(Expression<Func<ICardState>> predicate, ICardState expectedState, ICardState actualState, Func<bool> typeAs) {
                Predicate = predicate;
                ExpectedState = expectedState;
                ActualState = actualState;
                TypeAs = typeAs;
            }

            public Expression<Func<ICardState>> Predicate { get; }
            public ICardState ExpectedState { get; }
            public ICardState ActualState { get; }
            public Func<bool> TypeAs { get; }
            public override string ToString() => $"\t(x => x.{Predicate.GetName<ICardState>(), -8}) Expected: {ExpectedState, -10} Actual: {ActualState}";
        }

        public static CardStateTests For(ICardState originalState) => new CardStateTests(originalState);
        
        private readonly ICardState _originalState;
        private readonly List<TestCase> _testCases = new List<TestCase>();
        private ICardState _newState;
        private Expression<Func<ICardState>> _predicate;

        private CardStateTests(ICardState originalState) => _originalState = originalState;

        public ICardStateWhen And() => this;

        public void Assert() {
            var failedMessage = new StringBuilder();
            var failedTestCases = _testCases.Where(tc => !tc.TypeAs()).ToList();

            failedMessage.AppendLine($"{_originalState} State failed to transistion to:");
            failedTestCases.ForEach(tc => failedMessage.AppendLine(tc.ToString()));

            Xunit.Assert.False(failedTestCases.Any(), failedMessage.ToString());
        }

        public ICardStateAnd TransitionTo<TCardState>() where TCardState : ICardState {
            var testState = _newState.DeepClone();
            _testCases.Add(new TestCase(_predicate, Activator.CreateInstance<TCardState>(), testState, () => testState is TCardState));
            return this;
        }

        public ICardStateTransition When(Expression<Func<ICardState>> predicate) {
            _predicate = predicate;
            _newState = predicate.Compile().Invoke();
            return this;
        }
    }
}