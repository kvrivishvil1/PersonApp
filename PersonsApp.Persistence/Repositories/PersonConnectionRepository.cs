using Microsoft.EntityFrameworkCore;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Persistence.Repositories
{
    public class PersonConnectionRepository : BaseRepository<PersonConnection>, IPersonConnectionRepository
    {

        private readonly PersonsAppDbContext _dbContext;

        public PersonConnectionRepository(PersonsAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfPersonIsConnectedAsync(int personId)
            =>  await _dbContext.PersonConnections
                        .FirstOrDefaultAsync(x=> x.ConnectedPersonId == personId) != null;

        public async Task<IEnumerable<PersonConnection>> ListForReportAsync()
            => await _dbContext.PersonConnections.Include(x => x.Person).Include(x => x.ConnectionType).ToListAsync();
                        

        public async Task<PersonConnection> PersonConnectionSearchAsync(int connectionTypeId, int personId, int connectedPersonId)
        {
            var personConnection = await _dbContext.PersonConnections
                        .FirstOrDefaultAsync(x => x.ConnectionTypeId == connectionTypeId 
                                            && x.PersonId == personId
                                            && x.ConnectedPersonId == connectedPersonId);

            return personConnection;
        }
    }
}
