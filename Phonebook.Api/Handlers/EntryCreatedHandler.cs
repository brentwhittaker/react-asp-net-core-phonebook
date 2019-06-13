using Microsoft.Extensions.Logging;
using Phonebook.Api.Models;
using Phonebook.Api.Repositories;
using Phonebook.Common.Events;
using System.Threading.Tasks;

namespace Phonebook.Api.Handlers
{
    public class EntryCreatedHandler : IEventHandler<EntryCreated>
    {
        private readonly IEntryRepository _repository;
        private readonly ILogger<EntryCreatedHandler> _logger;

        public EntryCreatedHandler(IEntryRepository repository, ILogger<EntryCreatedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task HandleAsync(EntryCreated @event)
        {
            await _repository.AddAsync(new xEntry
            {
                Id = @event.Id,
                Name = @event.Name,
                PhoneNumber = @event.PhoneNumber
            });
            _logger.LogInformation($"Phonebook entry created: {@event.Id} {@event.Name} {@event.PhoneNumber}");
        }
    }
}
