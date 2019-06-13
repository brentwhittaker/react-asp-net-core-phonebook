using System;
using System.Threading.Tasks;
using Phonebook.Services.Entry.Domain.Models;

namespace Phonebook.Services.Entry.Domain.Services
{
    public interface IEntryService
    {
        Task<xEntry> GetAsync(Guid id);
        Task AddAsync(Guid id, string name, string phoneNumber);
    }
}
