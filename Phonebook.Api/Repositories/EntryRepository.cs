using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Phonebook.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Api.Repositories
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

        // TODO: fixme and add search term for name and phone number
        public async Task<IEnumerable<xEntry>> GetCollectionAsync(string searchTerm)
            => await Collection
                .AsQueryable()
                .ToListAsync();

        private IMongoCollection<xEntry> Collection
            => _database.GetCollection<xEntry>("Entries");
    }
}
