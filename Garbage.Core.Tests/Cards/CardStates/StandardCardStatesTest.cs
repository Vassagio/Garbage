using System;
using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardTypeStates;
using Garbage.Core.Tests.Cards.StateHelper;
using Xunit;

namespace Garbage.Core.Tests.Cards.CardStates {
    public class StandardCardStatesTest {
        private static readonly Func<Started> STARTED = () => State.Create<Started, StandardCardType>();
        private static readonly Func<Selected> SELECTED = () => State.Create<Selected, StandardCardType>();
        private static readonly Func<Hidden> HIDDEN = () => State.Create<Hidden, StandardCardType>();
        private static readonly Func<Locked> LOCKED = () => State.Create<Locked, StandardCardType>();
        private static readonly Func<Discarded> DISCARDED = () => State.Create<Discarded, StandardCardType>();
        private static readonly Func<StandardCardPlayed> PLAYED = () => State.Create<StandardCardPlayed, StandardCardType>();

        [Fact]
        public void Started_ChangeStates()
        {
            var state = STARTED();

            StateTests<ICardState>.For(state)
                .When(() => state.Start()).TransitionTo(STARTED).And()
                .When(() => state.Select()).TransitionTo(SELECTED).And()
                .When(() => state.Hide()).TransitionTo(STARTED).And()
                .When(() => state.Lock()).TransitionTo(STARTED).And()
                .When(() => state.Discard()).TransitionTo(STARTED).And()
                .When(() => state.Play()).TransitionTo(STARTED)
                .Assert();
        }

        [Fact]
        public void Selected_ChangeStates()
        {
            var state = State.Create<Selected, StandardCardType>();

            StateTests<ICardState>
                .For(state)
                .When(() => state.Start()).TransitionTo(SELECTED).And()
                .When(() => state.Select()).TransitionTo(SELECTED).And()
                .When(() => state.Hide()).TransitionTo(SELECTED).And()
                .When(() => state.Lock()).TransitionTo(SELECTED).And()
                .When(() => state.Discard()).TransitionTo(DISCARDED).And()
                .When(() => state.Play()).TransitionTo(PLAYED)
                .Assert();
        }

        [Fact]
        public void Hidden_ChangeStates()
        {
            var state = State.Create<Hidden, StandardCardType>();

            StateTests<ICardState>
                .For(state)
                .When(() => state.Start()).TransitionTo(STARTED).And()
                .When(() => state.Select()).TransitionTo(HIDDEN).And()
                .When(() => state.Hide()).TransitionTo(HIDDEN).And()
                .When(() => state.Lock()).TransitionTo(HIDDEN).And()
                .When(() => state.Discard()).TransitionTo(HIDDEN).And()
                .When(() => state.Play()).TransitionTo(HIDDEN)
                .Assert();
        }

        [Fact]
        public void Played_ChangeStates()
        {
            var state = State.Create<StandardCardPlayed, StandardCardType>();

            StateTests<ICardState>
                .For(state)
                .When(() => state.Start()).TransitionTo(PLAYED).And()
                .When(() => state.Select()).TransitionTo(PLAYED).And()
                .When(() => state.Hide()).TransitionTo(PLAYED).And()
                .When(() => state.Lock()).TransitionTo(LOCKED).And()
                .When(() => state.Discard()).TransitionTo(PLAYED).And()
                .When(() => state.Play()).TransitionTo(PLAYED)
                .Assert();
        }

        [Fact]
        public void Discarded_ChangeStates()
        {
            var state = State.Create<Discarded, StandardCardType>();

            StateTests<ICardState>
                .For(state)
                .When(() => state.Start()).TransitionTo(DISCARDED).And()
                .When(() => state.Select()).TransitionTo(DISCARDED).And()
                .When(() => state.Hide()).TransitionTo(HIDDEN).And()
                .When(() => state.Lock()).TransitionTo(DISCARDED).And()
                .When(() => state.Discard()).TransitionTo(DISCARDED).And()
                .When(() => state.Play()).TransitionTo(DISCARDED)
                .Assert();
        }

        [Fact]
        public void Locked_ChangeStates()
        {
            var state = State.Create<Locked, StandardCardType>();

            StateTests<ICardState>
                .For(state)
                .When(() => state.Start()).TransitionTo(LOCKED).And()
                .When(() => state.Select()).TransitionTo(LOCKED).And()
                .When(() => state.Hide()).TransitionTo(LOCKED).And()
                .When(() => state.Lock()).TransitionTo(LOCKED).And()
                .When(() => state.Discard()).TransitionTo(LOCKED).And()
                .When(() => state.Play()).TransitionTo(LOCKED)
                .Assert();
        }
    }
}