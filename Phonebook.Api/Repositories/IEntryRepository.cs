using Phonebook.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Api.Repositories
{
    public interface IEntryRepository
    {
        Task<IEnumerable<xEntry>> GetCollectionAsync(int pageNo, int pageSize);
        Task<IEnumerable<xEntry>> SearchCollectionAsync(int pageNo, int pageSize, string searchTerm);
        Task<int> TotalCountAsync();
        Task AddAsync(xEntry entry);
    }
}
