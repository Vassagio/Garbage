using System;
using Garbage.Core;
using Garbage.Core.Decks;

namespace Garbage.UI {
    public class Application : IApplication {
        private readonly IDeckFactory _deckFactory;

        public Application(IDeckFactory deckFactory) => _deckFactory = deckFactory;

        public void Run() {
            var deck = _deckFactory.Create().Shuffle();
            Console.WriteLine(deck);
            Console.ReadKey();
        }
    }
}