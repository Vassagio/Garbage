using Autofac;
using Garbage.Core;
using Garbage.Core.Decks;

namespace Garbage.UI {
    internal class Program {
        public static IContainer Container { get; set; }

        private static int Main(string[] args) {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BasicRandomizer>().As<IRandomizer>();
            builder.RegisterType<FisherYatesShuffler>().As<IShuffler>();
            builder.RegisterType<GarbageDeckFactory>().As<IDeckFactory>();

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope()) {
                scope.Resolve<IApplication>().Run();
            }

            return 0;
        }
    }
}