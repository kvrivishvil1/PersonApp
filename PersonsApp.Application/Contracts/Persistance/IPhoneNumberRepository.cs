using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Application.Contracts.Persistance
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumber>
    {
        Task<IEnumerable<PhoneNumber>> GetPersonsAllNumbersAsync(int personId);
        Task DeletePersonsAllNumbersAsync(int personId);
    }
}
