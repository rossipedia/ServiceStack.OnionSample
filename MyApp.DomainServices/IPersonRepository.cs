using System.Collections.Generic;
using MyApp.DomainModel;

namespace MyApp.DomainServices
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
    }
}