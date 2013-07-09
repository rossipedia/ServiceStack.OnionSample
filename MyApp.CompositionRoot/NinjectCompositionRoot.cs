using Funq;
using MyApp.DomainServices;
using Ninject;
using ServiceStack.ContainerAdapter.Ninject;

namespace MyApp.CompositionRoot
{
    public class NinjectCompositionRoot : ICompositionRoot
    {
        public void Compose(Container container)
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            container.Adapter = new NinjectContainerAdapter(kernel);
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
        }
    }
}
