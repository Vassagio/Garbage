using System.Collections.Generic;
using System.Linq;
using Project.Utilities.Randomizer;
using Xunit;

namespace Project.Utilities.Tests.Randomizer
{
    public class BasicRandomizerTest
    {
        [Fact]
        public void Initialize() {
            var randomizer = new BasicRandomizer();

            Assert.NotNull(randomizer);
        }

        [Fact]
        public void Next_ReturnsRandomNumber()
        {
            var randomNumbers = new List<int>();
            var randomizer = new BasicRandomizer();

            for (var i = 0; i < 100; i++) {
                randomNumbers.Add(randomizer.Next(i + 1));
            }

            Assert.True(randomNumbers.Distinct().Count() > 1);
            
        }
    }
}
