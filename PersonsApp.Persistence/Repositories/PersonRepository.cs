using Microsoft.EntityFrameworkCore;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {

        private readonly PersonsAppDbContext _dbContext;

        public PersonRepository(PersonsAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> GetOneWithPhoneNumbersAsync(int id)
            => await _dbContext.Persons
                        .Include(x => x.PhoneNumbers)
                        .FirstOrDefaultAsync(x => x.ID == id);

        public async Task<Person> GetPersonDetailedInfoAsync(int id)
            => await _dbContext.Persons
                        .Include(x => x.PersonConnections).ThenInclude(x=> x.ConnectionType)
                        .Include(x => x.PersonConnections).ThenInclude(x => x.ConnectedPerson)
                        .Include(x => x.PhoneNumbers).ThenInclude(x=> x.PhoneType)
                        .Include(x => x.Gender).Include(x => x.City)
                        .FirstOrDefaultAsync(x => x.ID == id);

        public async Task<Person> GetPersonGetWithPersonalNAsync(string personalN)
            => await _dbContext.Persons.FirstOrDefaultAsync(x => x.PersonalN == personalN);

        public Task<List<Person>> PersonDetailedSearchAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> PersonSearchAsync()
        {
            throw new NotImplementedException();
        }
    }
}
