using Funq;
using MyApp.DomainServices;

namespace MyApp.CompositionRoot
{
    public class FunqCompositionRoot : ICompositionRoot
    {
        public void Compose(Container container)
        {
            container.RegisterAs<PersonRepository, IPersonRepository>();
        }
    }
}