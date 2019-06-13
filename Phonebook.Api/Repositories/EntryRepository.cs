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

        // TODO: add sorting asc
        public async Task<IEnumerable<xEntry>> GetCollectionAsync(int pageNo, int pageSize)
            => await Collection
                .AsQueryable()
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .ToListAsync();

        // TODO: add search filter
        public async Task<IEnumerable<xEntry>> SearchCollectionAsync(int pageNo, int pageSize, string searchTerm)
            => await Collection
                .AsQueryable()
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .ToListAsync();

        public async Task<int> TotalCountAsync()
            => await Collection
                .AsQueryable()
                .CountAsync();

        private IMongoCollection<xEntry> Collection
            => _database.GetCollection<xEntry>("Entries");
    }
}
