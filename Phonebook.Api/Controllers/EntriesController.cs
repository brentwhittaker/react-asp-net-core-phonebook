using Microsoft.AspNetCore.Mvc;
using Phonebook.Api.Models;
using Phonebook.Api.Repositories;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Phonebook.Api.Controllers
{
    [Route("")]
    public class EntriesController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IEntryRepository _repository;

        public EntriesController(IBusClient busClient, IEntryRepository repository)
        {
            _busClient = busClient;
            _repository = repository;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] RequestEntry model)
        {
            var command = new Phonebook.Common.Commands.xEntry();
            command.Id = Guid.NewGuid();
            command.Name = model.Name;
            command.PhoneNumber = model.PhoneNumber;
            await _busClient.PublishAsync(command);
            return Accepted($"save/{command.Id}");
        }

        [HttpGet("contacts")]
        public IActionResult Get(string searchTerm, int pageNo = 1, int pageSize = 10)
        {
            if (pageNo < 0 || pageSize < 0)
            {
                return BadRequest();
            }
            var totalEntries = string.IsNullOrEmpty(searchTerm) ?
                _repository.TotalCount() :
                _repository.SearchCount(searchTerm);
            var entries = string.IsNullOrEmpty(searchTerm) ?
                _repository.GetCollection(pageNo, pageSize) :
                _repository.SearchCollection(pageNo, pageSize, searchTerm);

            var totalPages = Math.Ceiling((float)totalEntries / (float)pageSize);
            totalPages = totalPages == 0 ? totalPages = 1 : totalPages;
            return Json(new { entries, searchTerm, pageNo, totalPages });
        }
    }
}