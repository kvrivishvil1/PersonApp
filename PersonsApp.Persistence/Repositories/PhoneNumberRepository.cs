using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Persistence.Repositories
{
    public class PhoneNumberRepository : BaseRepository<PhoneNumber>, IPhoneNumberRepository
    {

        private readonly PersonsAppDbContext _dbContext;

        public PhoneNumberRepository(PersonsAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeletePersonsAllNumbersAsync(int personId)
        {
            var numbers = _dbContext.PhoneNumbers.Where(x => x.PersonId == personId);
            foreach(var number in numbers)
                await DeleteAsync(number);
        }

        public Task<IEnumerable<PhoneNumber>> GetPersonsAllNumbersAsync(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
