using System;

namespace Garbage.Core {
    public class BasicRandomizer : IRandomizer {
        private readonly Random _random = new Random();
        public int Next(int value) => _random.Next(value);
    }
}