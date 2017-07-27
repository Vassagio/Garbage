using System;
using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardTypeStates;
using Test.Utilities.StateHelper;
using Xunit;

namespace Garbage.Core.Tests.Cards.CardStates
{
    public class WildCardStatesTest
    {
        private static readonly Func<Started> STARTED = () => State.Create<Started, WildCardType>();
        private static readonly Func<Selected> SELECTED = () => State.Create<Selected, WildCardType>();
        private static readonly Func<Hidden> HIDDEN = () => State.Create<Hidden, WildCardType>();
        private static readonly Func<Discarded> DISCARDED = () => State.Create<Discarded, WildCardType>();
        private static readonly Func<WildCardPlayed> PLAYED = () => State.Create<WildCardPlayed, WildCardType>();

        [Fact]
        public void Started_ChangeStates()
        {
            var state = STARTED();

            StateTests<ICardState>
                .For(state)
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
            var state = SELECTED();

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
            var state = HIDDEN();

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
            var state = PLAYED();

            StateTests<ICardState>
                .For(state)
                .When(() => state.Start()).TransitionTo(PLAYED).And()
                .When(() => state.Select()).TransitionTo(SELECTED).And()
                .When(() => state.Hide()).TransitionTo(PLAYED).And()
                .When(() => state.Lock()).TransitionTo(PLAYED).And()
                .When(() => state.Discard()).TransitionTo(PLAYED).And()
                .When(() => state.Play()).TransitionTo(PLAYED)
                .Assert();
        }

        [Fact]
        public void Discarded_ChangeStates()
        {
            var state = DISCARDED();

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

    }
}