using System;
using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardStates.WildCardStates;
using Garbage.Core.Tests.Cards.CardStates.CardStateHelper;
using Xunit;

namespace Garbage.Core.Tests.Cards.CardStates
{
    public class WildCardStatesTest
    {

        [Fact]
        public void Started_ChangeStates()
        {
            var state = BuildCardAs<Started>();

            CardStateTests
                .For(state)
                .When(() => state.Start()).TransitionTo<Started>().And()
                .When(() => state.Select()).TransitionTo<Selected>().And()
                .When(() => state.Hide()).TransitionTo<Started>().And()
                .When(() => state.Lock()).TransitionTo<Started>().And()
                .When(() => state.Discard()).TransitionTo<Started>().And()
                .When(() => state.Play()).TransitionTo<Started>()
                .Assert();
        }

        [Fact]
        public void Selected_ChangeStates()
        {
            var state = BuildCardAs<Selected>();

            CardStateTests
                .For(state)
                .When(() => state.Start()).TransitionTo<Selected>().And()
                .When(() => state.Select()).TransitionTo<Selected>().And()
                .When(() => state.Hide()).TransitionTo<Selected>().And()
                .When(() => state.Lock()).TransitionTo<Selected>().And()
                .When(() => state.Discard()).TransitionTo<Discarded>().And()
                .When(() => state.Play()).TransitionTo<Played>()
                .Assert();
        }

        [Fact]
        public void Hidden_ChangeStates()
        {
            var state = BuildCardAs<Hidden>();

            CardStateTests
                .For(state)
                .When(() => state.Start()).TransitionTo<Started>().And()
                .When(() => state.Select()).TransitionTo<Hidden>().And()
                .When(() => state.Hide()).TransitionTo<Hidden>().And()
                .When(() => state.Lock()).TransitionTo<Hidden>().And()
                .When(() => state.Discard()).TransitionTo<Hidden>().And()
                .When(() => state.Play()).TransitionTo<Hidden>()
                .Assert();
        }

        [Fact]
        public void Played_ChangeStates()
        {
            var state = BuildCardAs<Played>();

            CardStateTests
                .For(state)
                .When(() => state.Start()).TransitionTo<Played>().And()
                .When(() => state.Select()).TransitionTo<Selected>().And()
                .When(() => state.Hide()).TransitionTo<Played>().And()
                .When(() => state.Lock()).TransitionTo<Played>().And()
                .When(() => state.Discard()).TransitionTo<Played>().And()
                .When(() => state.Play()).TransitionTo<Played>()
                .Assert();
        }

        [Fact]
        public void Discarded_ChangeStates()
        {
            var state = BuildCardAs<Discarded>();

            CardStateTests
                .For(state)
                .When(() => state.Start()).TransitionTo<Discarded>().And()
                .When(() => state.Select()).TransitionTo<Discarded>().And()
                .When(() => state.Hide()).TransitionTo<Hidden>().And()
                .When(() => state.Lock()).TransitionTo<Discarded>().And()
                .When(() => state.Discard()).TransitionTo<Discarded>().And()
                .When(() => state.Play()).TransitionTo<Discarded>()
                .Assert();
        }

        private static TCardState BuildCardAs<TCardState>() where TCardState : ICardState => Activator.CreateInstance<TCardState>();
    }
}