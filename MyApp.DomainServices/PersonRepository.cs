using System.Collections.Generic;
using MyApp.DomainModel;

namespace MyApp.DomainServices
{
    public class PersonRepository : IPersonRepository
    {
        public List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person { Name = "John Doe", Age = 24 },
                new Person { Name = "Jane Doe", Age = 21 },
            };
        }
    }
}
