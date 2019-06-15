using Phonebook.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Api.Repositories
{
    public interface IEntryRepository
    {
        IEnumerable<xEntry> GetCollection(int pageNo, int pageSize);
        IEnumerable<xEntry> SearchCollection(int pageNo, int pageSize, string searchTerm);
        int TotalCount();
        int SearchCount(string searchTerm);
        Task AddAsync(xEntry entry);
    }
}
