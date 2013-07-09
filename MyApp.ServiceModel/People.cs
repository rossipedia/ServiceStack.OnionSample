using System.Collections.Generic;
using MyApp.DomainModel;
using ServiceStack.ServiceHost;

namespace MyApp.ServiceModel
{
    [Route("/people")]
    public class People : IReturn<PeopleResponse>
    {
    }

    public class PeopleResponse
    {
        public List<Person> People { get; set; }
    }
}
