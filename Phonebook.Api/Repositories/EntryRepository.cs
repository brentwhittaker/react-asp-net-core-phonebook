using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Phonebook.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

        public IEnumerable<xEntry> GetCollection(int pageNo, int pageSize)
            => Collection
                .Find(new BsonDocument())
                .Sort(Builders<xEntry>.Sort.Ascending("Name"))
                .ToList()
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        public IEnumerable<xEntry> SearchCollection(int pageNo, int pageSize, string searchTerm)
            => Collection
                .Find(Builders<xEntry>.Filter.Regex("Name", new BsonRegularExpression(new Regex(searchTerm, RegexOptions.IgnoreCase)))
                        | Builders<xEntry>.Filter.Regex("PhoneNumber", new BsonRegularExpression(searchTerm)))
                .Sort(Builders<xEntry>.Sort.Ascending("Name"))
                .ToList()
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        public int TotalCount()
            => Collection
                .AsQueryable()
                .Count();

        public int SearchCount(string searchTerm)
            => Collection
                .Find(Builders<xEntry>.Filter.Regex("Name", new BsonRegularExpression(new Regex(searchTerm, RegexOptions.IgnoreCase)))
                        | Builders<xEntry>.Filter.Regex("PhoneNumber", new BsonRegularExpression(searchTerm)))
                .ToList()
                .Count();

        private IMongoCollection<xEntry> Collection
            => _database.GetCollection<xEntry>("Entries");
    }
}
