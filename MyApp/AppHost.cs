using Funq;
using MyApp.CompositionRoot;
using MyApp.ServiceInterface;
using ServiceStack.WebHost.Endpoints;

namespace SSOnionTest
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("MyApp", typeof(PeopleService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            //var root = new NinjectCompositionRoot();
            var root = new UnityCompositionRoot();
            //var root = new FunqCompositionRoot();
            root.Compose(container);
        }
    }
}