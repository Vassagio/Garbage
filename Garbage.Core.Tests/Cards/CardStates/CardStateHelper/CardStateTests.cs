using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Garbage.Core.Cards.CardStates;

namespace Garbage.Core.Tests.Cards.CardStates.CardStateHelper {
    public class CardStateTests : ICardStateWhen, ICardStateTransition, ICardStateAnd {
        internal struct TestCase {
            public TestCase(ICardState expectedState, ICardState actualState, Expression<Func<bool>> predicate) {
                ExpectedState = expectedState;
                ActualState = actualState;
                Predicate = predicate;
            }

            public ICardState ExpectedState { get; }
            public ICardState ActualState { get; }
            public Expression<Func<bool>> Predicate { get; }
            public override string ToString() => $"\tWhen {Predicate.Body} Expected: {ExpectedState}\tActual: {ActualState}";
        }

        public static CardStateTests For(ICardState originalState) => new CardStateTests(originalState);

        private readonly ICardState _originalState;
        private readonly List<TestCase> _testCases = new List<TestCase>();
        private ICardState _newState;

        private CardStateTests(ICardState originalState) => _originalState = originalState;

        public ICardStateWhen And() => this;

        public void Assert() {
            var failedMessage = new StringBuilder();
            var failedTestCases = _testCases.Where(tc => !tc.Predicate.Compile().Invoke()).ToList();

            failedMessage.AppendLine($"{_originalState} State failed to transistion to:");
            failedTestCases.ForEach(tc => failedMessage.AppendLine(tc.ToString()));

            Xunit.Assert.False(failedTestCases.Any(), failedMessage.ToString());
        }

        public ICardStateAnd TransitionTo<TCardState>() where TCardState : ICardState {
            var testState = _newState.DeepClone();
            _testCases.Add(new TestCase(Activator.CreateInstance<TCardState>(), testState, () => testState is TCardState));
            return this;
        }

        public ICardStateTransition When(Func<ICardState> predicate) {
            _newState = predicate();
            return this;
        }
    }
}