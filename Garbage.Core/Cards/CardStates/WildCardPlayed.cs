﻿using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards.CardStates {
    internal class WildCardPlayed : IPlayedCardState {
        private readonly ICardTypeState _cardType;

        public WildCardPlayed(ICardTypeState cardType) => _cardType = cardType;
        public ICardState Start() => this;
        public ICardState Select()=> new Selected(_cardType);
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new WildCardPlayed(_cardType);
        public override string ToString() => nameof(WildCardPlayed);
    }
}