using Microsoft.Extensions.Logging;
using Phonebook.Common.Commands;
using Phonebook.Common.Events;
using Phonebook.Common.Exceptions;
using Phonebook.Services.Entry.Domain.Services;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Phonebook.Services.Entry.Handlers
{
    public class InsertEntryHandler : ICommandHandler<xEntry>
    {
        private readonly IBusClient _busClient;
        private readonly IEntryService _service;
        private readonly ILogger<InsertEntryHandler> _logger;

        public InsertEntryHandler(IBusClient busClient,
            IEntryService service,
            ILogger<InsertEntryHandler> logger)
        {
            _busClient = busClient;
            _service = service;
            _logger = logger;
        }
        public async Task HandleAsync(xEntry command)
        {
            try
            {
                _logger.LogInformation($"Creating phonebook entry: {command.Name} {command.PhoneNumber}");

                await _service.AddAsync(
                    command.Id,
                    command.Name,
                    command.PhoneNumber
                );

                var xEntry = await _service.GetAsync(command.Id);

                await _busClient.PublishAsync(new EntryCreated(
                    xEntry.Id,
                    xEntry.Name,
                    xEntry.PhoneNumber
                ));

                return;
            }
            catch (PhonebookException ex)
            {
                await _busClient.PublishAsync(new EntryRejected(
                    command.Id,
                    ex.Code,
                    ex.Message
                ));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new EntryRejected(
                    command.Id,
                    "error",
                    ex.Message
                ));
                _logger.LogError(ex.Message);
            }
        }
    }
}
