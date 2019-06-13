using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Phonebook.Services.Entry.Domain.Models;
using Phonebook.Services.Entry.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Services.Entry.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly IMongoDatabase _database;

        public EntryRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(xEntry entry)
            => await Collection.InsertOneAsync(entry);

        public async Task<xEntry> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<xEntry> Collection
            => _database.GetCollection<xEntry>("Entries");
    }
}
