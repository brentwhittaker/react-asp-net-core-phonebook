using Phonebook.Services.Entry.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Phonebook.Services.Entry.Domain.Repositories
{
    public interface IEntryRepository
    {
        Task<xEntry> GetAsync(Guid id);
        Task AddAsync(xEntry entry);
    }
}
