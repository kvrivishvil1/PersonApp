using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Application.Contracts.Persistance
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> PersonDetailedInfo(int id);
        Task<Person> PersonGetWithPersonalN(string personalN);
        Task<List<Person>> PersonSearch();
        Task<List<Person>> PersonDetailedSearch();
    }
}
