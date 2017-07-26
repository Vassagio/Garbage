﻿namespace Garbage.Core.Cards.CardStates.WildCardStates {
    internal class Started : ICardState {
        public ICardState Start() => this;
        public ICardState Select() => new Selected();        
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Started();
        public override string ToString() => nameof(Started);
    }
}