using Phonebook.Services.Entry.Domain.Models;
using Phonebook.Services.Entry.Domain.Repositories;
using Phonebook.Services.Entry.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Phonebook.Services.Entry.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _repository;

        public EntryService(IEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Guid id, string name, string phoneBook)
        {
            var xEntry = new xEntry(id, name, phoneBook);
            await _repository.AddAsync(xEntry);
        }

        public async Task<xEntry> GetAsync(Guid id)
            => await _repository.GetAsync(id);

    }
}
