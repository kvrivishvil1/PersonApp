using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonsApp.Application.Contracts.Persistance
{
    public interface IPersonConnectionRepository : IRepository<PersonConnection>
    {
        Task<PersonConnection> PersonConnectionSearchAsync(int connectionTypeId, int personId, int connectedPersonId);
        Task<bool> CheckIfPersonIsConnectedAsync(int personId);
        Task<IEnumerable<PersonConnection>> ListForReportAsync();
    }
}
