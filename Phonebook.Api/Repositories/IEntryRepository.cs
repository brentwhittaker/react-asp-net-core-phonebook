using Phonebook.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Api.Repositories
{
    public interface IEntryRepository
    {
        Task<IEnumerable<xEntry>> GetCollectionAsync(string searchTerm);
        Task AddAsync(xEntry entry);
    }
}
