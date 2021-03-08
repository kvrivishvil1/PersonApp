using PersonsApp.Application.Features.Persons.Queries.GetPersonList;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Application.Contracts.Persistance
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetPersonDetailedInfoAsync(int id);
        Task<Person> GetPersonGetWithPersonalNAsync(string personalN);
        Task<IEnumerable<Person>> PersonSearchAsync(GetPersonsListQuery filter);
        Task<Person> GetOneWithPhoneNumbersAsync(int id);
    }
}
