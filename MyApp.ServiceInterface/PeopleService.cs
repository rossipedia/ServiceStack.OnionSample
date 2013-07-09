using MyApp.DomainServices;
using MyApp.ServiceModel;
using ServiceStack.ServiceInterface;

namespace MyApp.ServiceInterface
{
    public class PeopleService : Service
    {
        private readonly IPersonRepository _peopleRepository;

        public PeopleService(IPersonRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public PeopleResponse Get(People request)
        {
            return new PeopleResponse
            {
                People = _peopleRepository.GetPeople()
            };
        }
    }
}
